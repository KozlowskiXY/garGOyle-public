using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Handles Player shooting
public class PlayerShooting : MonoBehaviour
{
    private ShootingState currentState;
    public string currentStateName;
    public Color playerColor = Color.white;
    
    // instances of states
    public FireState fireState = new FireState();
    public ChargedState chargedState = new ChargedState();
    // Lvl 1 has only a single state without transitions to other states
    public FireStateLvl1 fireStateLvl1 = new FireStateLvl1();
    
    public GameObject watercontainer;
    public WaterBar waterbar;

    public GameObject sammy;
    
    
    //=========================================================================
    //This handles how and when to fire a rocket
    
    public GameObject defaultFire;//Rocket shot by the player
    
    public GameObject chargedFire;

    public GameObject ammo;
    
    public GameObject Message;
    public SpriteRenderer renderer;
    
    [SerializeField]
    private float fireDelay = 0.2f; // fire rate
    private float nextFire = -1f; // cooldown time

    // Used for disabling text after displaying
    public void DisableText()
    {
        Message.GetComponent<Text>().enabled = false;
    }

    private bool shotMoneyBag = false;
    public bool checkPlayerShotMoneyBag()
    {
        if (shotMoneyBag)
        {
            shotMoneyBag = false;
            return true;
        }

        return false;
        
    } 


    public void fireFire()
    {
        if (Time.time > nextFire)
        {
            
            nextFire = Time.time + fireDelay;
            if (ammo == chargedFire)
            {
                FindObjectOfType<AudioManager>().Play("garGOyleChargedShot");
                if (SceneManager.GetActiveScene().name != "Level3") waterbar.reduceWaterLevel();
            }
            else FindObjectOfType<AudioManager>().Play("player-shoot");

            if (SceneManager.GetActiveScene().name == "Level3" && ammo == chargedFire)
            {
                shotMoneyBag = true;
                return; 
            }

            Instantiate(ammo, transform.position, Quaternion.identity);
        }
        else
        {
            Message.GetComponent<Text>().enabled = true;
            FindObjectOfType<AudioManager>().Play("player-shoot-fail");
            Invoke("DisableText", fireDelay);
        }
    }
    
    
    
    void Start()
    {
        currentState = fireStateLvl1;
        if (SceneManager.GetActiveScene().name == "Level5" || SceneManager.GetActiveScene().name == "Level2" || SceneManager.GetActiveScene().name == "Level3" || SceneManager.GetActiveScene().name == "TutorialLevel")
        {
            renderer = sammy.GetComponent<SpriteRenderer>();
            currentState = fireState;
            watercontainer = GameObject.Find("WaterBar");
            waterbar = watercontainer.GetComponent<WaterBar>();
        }
        currentStateName = currentState.ToString();
    }

    
    void Update()
    {
        currentState = currentState.doState(this);
        currentStateName = currentState.ToString();
        //Debug.Log(currentStateName);
    }
}
