using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// This handles all the player avatar's actions

public class Player : MonoBehaviour
{
    //=========================================================================
    //This segment handles receiving movement input

    //width and height of the area the player can move in
    private int width = 100;
    private int height = 30;

    Rigidbody rigbod;

    [SerializeField]
    private float speedfaktor;//Player movement speed

    private Vector2 movement = new Vector2(0, 0);//Input values of player movement

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    //=========================================================================
    //This handels switching the 3 sprites of the flying animation
    public Sprite WingsUP;
    public Sprite WingsMID1;
    public Sprite WingsMID2;
    public Sprite WingsDOWN;
    public GameObject Sammy;
    private SpriteRenderer render;
    private float flighttimer = 0;

    private void PlayerFlight()
    {
        flighttimer = (flighttimer + Time.deltaTime) % 1;
        if (flighttimer < 0.2)
        {
            render.sprite = WingsDOWN;
        }
        else if (flighttimer < 0.35) {
            render.sprite = WingsMID1;
        }
        else if (flighttimer < 0.5)
        {
            render.sprite = WingsMID2;
        }
        else if (flighttimer < 0.65)
        {
            render.sprite = WingsUP;
        }
        else if (flighttimer < 0.8)
        {
            render.sprite = WingsMID2;
        }
        else if (flighttimer < 0.9)
        {
            render.sprite = WingsMID1;
        }
    }
    //=========================================================================
    //This handels Player interaction with ghosts in level 3
    public GameObject ghost_prefab;
    bool ghostsExist = false;
    private GameObject ghost1;
    private GameObject ghost2;
    public void GhostStart()//Should be called when the player picks up gold
    {
        if (!ghostsExist)
        {
            ghostsExist = true;
            ghost1 = Instantiate(ghost_prefab, new Vector3(0, 60, 0), Quaternion.identity);
            ghost2 = Instantiate(ghost_prefab, new Vector3(100, 60, 0), Quaternion.identity);
        }

    }
    public void GhostAttack()//Called by ghost on collision with player
    {
        //Debug.Log("Player attacked by ghost");
        FindObjectOfType<HealthBarController>().reduceHealth();
        //Add state switch for player here!!!
        //...
        //(How the player loses the gold sack, should be a function call, define logic in its own place)
        try
        {
            ghost1.GetComponent<GhostInstanceScript>().StopGhost(true);
            ghost2.GetComponent<GhostInstanceScript>().StopGhost(true);
        }
        catch(NullReferenceException)
        {
            Debug.LogError("Attempt to access ghost script, but ghost was null! (at Player.GhostAttack)");
        }
        
    }
    public void GhostStop()//Should be called when the gold sack is expended
    {
        //Debug.Log("Ghosts stopped");
        try
        {
            ghostsExist = false;
            ghost1.GetComponent<GhostInstanceScript>().StopGhost(false);
            ghost2.GetComponent<GhostInstanceScript>().StopGhost(false);
        }
        catch (NullReferenceException)
        {
            Debug.LogError("Attempt to access ghost script, but ghost was null! (at Player.GhostStop)");
        }
    }


    //*************************************************************************
    // Player is in default state in the beginning
    private GameObject watercontainer;
    private WaterBar waterbar;
    private HealthBarController healthbar;
    private PlayerShooting shooting;
    
    void Start()
    {
        render = Sammy.GetComponent<SpriteRenderer>();
        rigbod = GetComponent<Rigidbody>();
        //ammo = myprefab;
        healthbar = FindObjectOfType<HealthBarController>();
        shooting = GetComponent<PlayerShooting>();

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            watercontainer = GameObject.Find("WaterBar");
            waterbar = watercontainer.GetComponent<WaterBar>();
        }

    }

    private IEnumerator hitCooldownVis()
    {   
        //Debug.Log("Mulm");
        shooting.playerColor = Color.red;
        yield return new WaitForSeconds(hitCooldown);
        shooting.playerColor = Color.white;
    }
    
    private float hitCooldown = 0.5F;

    private float hitTimer = 0;

    // Detects Player hitting default Asteroid and water Asteroid
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            if (Time.time > hitTimer)
            {
                FindObjectOfType<HealthBarController>().reduceHealth();
                hitTimer = Time.time + hitCooldown;
                StartCoroutine(hitCooldownVis());
            }
        }
        else if (collision.gameObject.layer == 13)
        {
            Destroy(collision.gameObject);
            FindObjectOfType<HealthBarController>().restoreHealth();
        }
    }


    private void FixedUpdate()
    {
        //Player flight animation
        PlayerFlight();
        //This handles player movement and ensures the avatar stays inside the game world
        rigbod.velocity = new Vector3(0, 0, 0);
        rigbod.MovePosition(new Vector3(
            Math.Max(Math.Min(transform.position.x + (speedfaktor * movement.x), width), 0),
            Math.Max(Math.Min(transform.position.y + (speedfaktor * movement.y), height), 0),
            0
            ));
    }



    //**********************************************
    
    const float c_xScale = 4;
    const float c_yScale = 4;
    const float c_growingSpeed = 0.075f;
    const float c_explosionInteval = 0.1f;
    float m_additionalSize = 0;
    float m_explosionIntervalTime = 0;
    public Transform tr;
    public GameObject explosionParticleGroup;
    bool ateTooMuch = false;

    //increases the players size when eating apples
    private void getFat()
    {
        m_additionalSize = FindObjectOfType<WaterBar>().getWaterLevel() * c_growingSpeed;

        tr.localScale = new Vector3(c_xScale + m_additionalSize,
                                    c_yScale + m_additionalSize,
                                    1);
    }

    private void throwUp()
    {
        if(FindObjectOfType<WaterBar>().getWaterLevel() >= FindObjectOfType<WaterBar>().getMaxWaterLevel() && !ateTooMuch)
        {
            FindObjectOfType<AudioManager>().Play("garGOyleThrowUp");
            m_explosionIntervalTime = 0;
            ateTooMuch = true;
            Physics.IgnoreLayerCollision(15, 15); //explosion particle ignore phisics
        }

        if (ateTooMuch && m_explosionIntervalTime > c_explosionInteval)
        {
            m_explosionIntervalTime = 0;
            Instantiate(explosionParticleGroup, transform.position, Quaternion.identity);
            FindObjectOfType<WaterBar>().reduceWaterLevelBy(1f);
            if(FindObjectOfType<WaterBar>().getWaterLevel() <= 1)
            {
                ateTooMuch = false;
            }
        }

    }


    private float m_appleEatingSoundTime = 0;
    private const float c_appleEatingSoundDuration = 0.05f;

    public void playEatingSound()
    {
        if (m_appleEatingSoundTime >= c_appleEatingSoundDuration)
        {
            FindObjectOfType<AudioManager>().Play("garGOyleEatApple" + UnityEngine.Random.Range(1, 3));
            m_appleEatingSoundTime = 0;
        }
    }

    private bool holdsMoneyBag = false;
    public void setHoldsMoneyBag(bool isHoldingMoneyBag)
    {
        holdsMoneyBag = isHoldingMoneyBag;
    }

    private void Update()
    {
        m_explosionIntervalTime += Time.deltaTime;
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            getFat();
            throwUp();
        }
        m_appleEatingSoundTime += Time.deltaTime;
        //Debug.Log(m_appleEatingSoundTime);

    }

}
