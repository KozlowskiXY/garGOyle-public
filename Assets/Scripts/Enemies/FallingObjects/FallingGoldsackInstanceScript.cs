using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGoldsackInstanceScript : MonoBehaviour
{
    bool isOnPlayer = false;
    bool isOnBoss = true;
    bool wasShotByPlayer = false;
    bool isHidden = true;

    public GameObject player;
    public GameObject boss;
    public GameObject waterBar;
    public Transform tr;
    public Rigidbody m_rb;
    private PlayerShooting shooting;

    private const float c_positionRelativeBoss = -5;
    private const float c_positionRelativePlayer = +5;
    private const float c_throwingForce = 4500f;
    private const float c_massWhenDropped = 0.000006f;
    private const float c_massWhenThrown = 60f;

    private float m_timeSinceThrown = 0;
    private float c_throwingDuration = 2;
    private float m_timeSinceHidden = 0;
    private float c_hiddingDuration = 4;




    private void Start()
    {
        shooting = GameObject.Find("Player").GetComponent<PlayerShooting>();
        Physics.IgnoreLayerCollision(16, 13);
        Physics.IgnoreLayerCollision(17, 13);
        Physics.IgnoreLayerCollision(16, 11);
        Physics.IgnoreLayerCollision(17, 11);
        Physics.IgnoreLayerCollision(16, 10);
        Physics.IgnoreLayerCollision(17, 10);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!isOnBoss && !wasShotByPlayer)
            {
                isOnPlayer = true;
                player.GetComponent<Player>().GhostStart();
                //Debug.Log("Caught");
                FindObjectOfType<AudioManager>().Play("garGOyleGhostsSpawning");
            }
        }

        if (collision.gameObject.tag == "Stone" && wasShotByPlayer)
        {
            m_rb.AddForce(0, -1000, 0, ForceMode.Impulse);
            isOnPlayer = false;
            isOnBoss = false;
            wasShotByPlayer = false;
            isHidden = false;
            m_rb.mass = c_massWhenDropped;
            gameObject.layer = 16;

            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("garGOyleMoneyBagDestroy");
            FindObjectOfType<AudioManager>().Play("GargoyleDeath");
            //Debug.Log("HitStone");
        }
        if (collision.gameObject.tag == "Stone" && !wasShotByPlayer && !isOnBoss && !isOnPlayer)
        {
            playMoneyCollisionSound();
        }
        if (collision.gameObject.tag == "Asteroid" && !wasShotByPlayer && !isOnBoss && !isOnPlayer)
        {
            playMoneyCollisionSound();
        }
    }

    public void dropMoneyBag()
    {
        //Debug.Log("dropped");
        isOnBoss = false;
    }

    //called when Ghost Steals Bag
    public void stealMoneyBag()
    {
        isOnPlayer = false;
        isOnBoss = true;
        wasShotByPlayer = false;
        isHidden = true;
        m_rb.mass = c_massWhenDropped;
        gameObject.layer = 16;
        m_timeSinceHidden = 0;
        FindObjectOfType<AudioManager>().Play("garGOyleMoneyBagDestroy");
        player.GetComponent<Player>().GhostStop();
        waterBar.GetComponent<WaterBar>().setMinWaterLevel();
    }

    //makes bag stick to boss or player
    void sticking()
    {
        if (isOnBoss && !isOnPlayer)
        {
            tr.position = new Vector3(boss.transform.position.x, boss.transform.position.y + c_positionRelativeBoss, 1);

        }
        else if (isOnPlayer && !isOnBoss)
        {
            tr.position = new Vector3(player.transform.position.x, player.transform.position.y + c_positionRelativePlayer, 1);
            
        }
    }

    bool waterIsEmpty = true;

    //fills and empties waterBar if player holds moneybag
    void updateWaterBar()
    {
        if (isOnPlayer && waterIsEmpty)
        {
            waterBar.GetComponent<WaterBar>().setMaxWaterLevel();
            waterIsEmpty = false;
        }
        else if (!isOnPlayer && !waterIsEmpty)
        {
            waterBar.GetComponent<WaterBar>().setMinWaterLevel();
            waterIsEmpty = true;
        }
    }

    //handles player throwing
    void throwMoneyBag()
    {
        m_timeSinceThrown += Time.deltaTime;
        if (m_timeSinceThrown >= c_throwingDuration && wasShotByPlayer)
        {
            gameObject.layer = 16;
            m_rb.mass = c_massWhenDropped;
            //Debug.Log("Finished Throwing");
            wasShotByPlayer = false;
        }

        if (shooting.checkPlayerShotMoneyBag())
        {
            gameObject.layer = 17;
            FindObjectOfType<AudioManager>().Play("garGOyleGhostsDespawn");
            m_rb.mass = c_massWhenThrown;
            wasShotByPlayer = true;
            m_timeSinceThrown = 0;
            player.GetComponent<Player>().GhostStop();
            m_rb.AddForce(0, c_throwingForce, 0, ForceMode.Impulse);
            isOnPlayer = false;
        }
    }

    //shows money bag after it was hidden
    void showMoneyBag()
    {
        if (isHidden && m_timeSinceHidden > c_hiddingDuration)
        {
            isOnPlayer = false;
            isOnBoss = true;
            wasShotByPlayer = false;
            isHidden = false;
            m_rb.mass = c_massWhenDropped;
            gameObject.layer = 16;
        }
    }

    //hides moneybag when boss is hit or outside screen
    void hideMoneybag()
    {
        m_timeSinceHidden += Time.deltaTime;
        if (!isHidden && (tr.position.y < -15 || tr.position.y > 70))
        {
            isHidden = true;
            m_timeSinceHidden = 0;
        }

        if (isHidden)
        {
            tr.position = new Vector3(boss.transform.position.x, boss.transform.position.y + c_positionRelativeBoss, 10);
        }
    }

    //called by boss Lvl3
    public void setIsHidden()
    {
        isHidden = true;
        isOnPlayer = false;
        isOnBoss = true;
        wasShotByPlayer = false;
        m_rb.mass = c_massWhenDropped;
        gameObject.layer = 16;
        m_timeSinceHidden = 0;
        FindObjectOfType<AudioManager>().Play("garGOyleMoneyBagDestroy");
    }
    private void Update()
    {

        if (!isHidden)
        {
            sticking();
            updateWaterBar();

            //communicates to player if he is holding moneyBag
            player.GetComponent<Player>().setHoldsMoneyBag(isOnPlayer);
            throwMoneyBag();
        }

        showMoneyBag();
        hideMoneybag();
        timeSinceLastHit = Time.deltaTime;

    }

    float timeSinceLastHit = 0;
    void playMoneyCollisionSound()
    {
        if(timeSinceLastHit < 0.5f)
        {
            FindObjectOfType<AudioManager>().Play("garGOyleMoneyBagHit" + Random.Range(1, 3));
            timeSinceLastHit = 0;
        }
    }
}


