using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel5 : BossTemplate
{

   
    //*******************************************************************
    //******************* Level 2 Boss members ***************************
    //*******************************************************************

    public GameObject apple;
    protected float m_waterCoolDownTime = 0;
    protected float c_waterCoolDownDuration = 0.65f;

    private GameObject watercontainer;
    private WaterBar waterbar;
    


    //updates all times
    protected override void timeManager()
    {
        base.timeManager();
        m_waterCoolDownTime += Time.deltaTime;
    }

    private int m_appleSoundNumber = 1;

    protected void waterAttack()
    {
        
        if (isHovering && m_waterCoolDownTime > c_waterCoolDownDuration)
        {
            FindObjectOfType<AudioManager>().Play("garGOyleDropApple" + m_appleSoundNumber);
            m_appleSoundNumber++;

            if (m_appleSoundNumber > 3) m_appleSoundNumber = 1;

            Instantiate(apple, new Vector3(m_x, m_y, 0), Quaternion.identity);
            m_waterCoolDownTime = 0;
        }
    }

    public const int c_bossMaxLives = 3; 
    public int lives = c_bossMaxLives;
    private int m_bossHitSoundNumber = 0;
    private void reduceHealth()
    {
        
        if (lives == 0)
        {
            isAlive = false;
            FindObjectOfType<AudioManager>().Play("garGOyleBossKill");
        }
        else
        {
            m_bossHitSoundNumber = 1 + c_bossMaxLives - lives;
            FindObjectOfType<AudioManager>().Play("garGOyleBossHit" + m_bossHitSoundNumber);
            lives--;
        }
    }
    private IEnumerator displayHit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.7F);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(other.gameObject);
            StartCoroutine(displayHit());
            reduceHealth();
        }
    }

    private void Start()
    {
        watercontainer = GameObject.Find("WaterBar");
        waterbar = watercontainer.GetComponent<WaterBar>();
    }

    private void Update()
    {
        
        timeManager();
        if (isAlive)
        {
            wobble();
            stoneAttack();
            waterAttack();
        }
        else
        {
            wobble();
            shrink("CutScene5END1");
        }


    }

}
