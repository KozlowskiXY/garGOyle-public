using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossTemplate : MonoBehaviour
{
    //*******************************************************************
    //******************* Level 1 Boss memers ***************************
    //*******************************************************************

    //settings c_ meants constant
    protected const float c_defaultHeight = 50;
    protected const float c_stoneCoolDownDuration = 5;
    protected       float c_hoveringDuration = 2.5f;
    protected const float c_movingDuration = 3;

    //represents boss movement m_ means mutable member
    protected float m_x = 50;
    protected float m_y = c_defaultHeight;
    protected float m_xOld = 0;
    protected float m_xNew = 0;
    protected float m_relativeXPosition = 0;

    //represents state of boss
    protected bool isRightToPlayer = true;
    protected bool isLeftToPlayer = false;
    protected bool isStoneAttacking = false;
    protected bool isChasing = false;
    protected bool isAbove = false;
    protected bool isHovering = false;
    protected bool isShooting = false;
    public bool isAlive = true;

    public GameObject player;
    public Transform tr;

    [SerializeField]
    protected GameObject stone;

    protected float m_time = 0;
    protected float m_stoneCoolDownTime = 0;
    protected float m_movingToPlayerTime = 0;
    protected float m_hoveringOverPlayerTime = 0;

    //*********************************************************

    protected void wobble()
    {
        tr.position = new Vector3(m_x + 1.5f * Mathf.Sin(m_time * 0.001f * 1f),
                                  m_y + 4 * Mathf.Sin(m_time * 3f),
                                  0);
    }

    //*********************************************************

    //moves to player position until above the player
    protected void moveTo_m_xNew()
    {


        if (!isAbove && m_movingToPlayerTime < c_movingDuration)
        {
            //s = s0 + t*v
            m_x = m_xOld + m_movingToPlayerTime * -((m_xOld - m_xNew) / c_movingDuration);
        }
        else if (!isAbove && m_movingToPlayerTime > c_movingDuration)
        {
            isChasing = false;
            isStoneAttacking = false;
        }
        else if (isAbove)
        {
            isChasing = false;
            isHovering = true;
            m_hoveringOverPlayerTime = 0;
        }
    }

    //*********************************************************

    //while relativeXPosition negative, the boss is on the left of the player. otherwise right
    protected void detectIfIsAbove()
    {
        m_relativeXPosition = m_x - player.transform.position.x;

        if (m_relativeXPosition > 0 && isLeftToPlayer)
        {
            isAbove = true;
            isLeftToPlayer = false;
            isRightToPlayer = true;
        }
        else if (m_relativeXPosition < 0 && isRightToPlayer)
        {
            isAbove = true;
            isLeftToPlayer = true;
            isRightToPlayer = false;
        }
        else if (Mathf.Abs(m_relativeXPosition) > 3)
        {
            isAbove = false;
        }
    }

    //*********************************************************

    //hover over player for t sec
    protected void hoverOverPlayer()
    {
        if (m_hoveringOverPlayerTime < c_hoveringDuration)
        {
            m_x = player.transform.position.x;
        }
        else if (m_hoveringOverPlayerTime > c_hoveringDuration)
        {
            isHovering = false;
            isShooting = true;
        }

    }

    //*********************************************************

    virtual protected void shot()
    {
        isStoneAttacking = false;
        isShooting = false;
        isAbove = false;
        m_stoneCoolDownTime = 0;
        Instantiate(stone, new Vector3(m_x, m_y, 0), Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("garGOyleDropStone");
    }

    //*********************************************************

    //moves on top of player and drops a stone every t sec
    protected void stoneAttack()
    {
        detectIfIsAbove();
        if (!isStoneAttacking && m_stoneCoolDownTime > c_stoneCoolDownDuration)
        {
            m_xOld = m_x;
            m_xNew = player.transform.position.x;
            m_movingToPlayerTime = 0;
            isStoneAttacking = true;
            isChasing = true;
        }

        if (isChasing && isStoneAttacking && !isHovering && !isShooting) moveTo_m_xNew();
        if (!isChasing && isStoneAttacking && isHovering && !isShooting) hoverOverPlayer();
        if (!isChasing && isStoneAttacking && !isHovering && isShooting) shot();
    }

    //updates all times
    protected virtual void timeManager()
    {
        m_time += Time.deltaTime;
        m_stoneCoolDownTime += Time.deltaTime;
        m_movingToPlayerTime += Time.deltaTime;
        m_hoveringOverPlayerTime += Time.deltaTime;
    }

    // Shrinks Boss and when to small, eliminate him :(
    protected void shrink(string nextscene)
    {
        float scaleX = tr.localScale.x;
        if (scaleX <= 1)
        {
            SceneManager.LoadScene(nextscene);
        }
        tr.localScale = tr.localScale * 0.98F;
    }

    
}
