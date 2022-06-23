using System;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class GhostInstanceScript : MonoBehaviour
{
    private GameObject player;
    public GameObject appear_effect;
    public GameObject vanish_effect;
    public GameObject steal_effect;
    private Vector3 posn;
    public GameObject moneyBag;

    public void StopGhost(bool money)
    //Called by the Player when:
    //  1) The ghost attacked the player and stole the money (true)
    //  2) The player used the money and the ghost vanishes
    {
        //TODO: Add particles etc for the different events
        //Debug.Log(money ? "Ghost stole the players money!" : "Ghost vanishes without money...");
        Destroy(gameObject);
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Instantiate(appear_effect, transform.position, Quaternion.identity);
        moneyBag = GameObject.FindWithTag("Goldsack");
        if(player == null)
        {
            Debug.LogError("player not found by ghost");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            moneyBag.GetComponent<FallingGoldsackInstanceScript>().stealMoneyBag();
            try
            {
                other.GetComponent<Player>().GhostAttack();
                Instantiate(steal_effect, transform.position, Quaternion.identity);
            }
            catch(NullReferenceException)
            {
                Debug.LogError("Object without playerscript but with tag Player encountered by ghost");
            }
        }
    }

    private void OnDestroy()
    {
        Instantiate(vanish_effect, transform.position, Quaternion.identity);
    }

    void Update()
    {
        posn = player.transform.position;
        transform.position = new Vector3(posn.x > transform.position.x ? transform.position.x + (Time.deltaTime * 5) : transform.position.x - (Time.deltaTime * 5),
                                         posn.y > transform.position.y ? transform.position.y + (Time.deltaTime * 10) : transform.position.y - (Time.deltaTime * 10),
                                         0);
    }
}
