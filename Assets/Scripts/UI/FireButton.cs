using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem.Interactions;

// Controls Fire Button using hold interaction. ! See PlayerControls.inputactions
// for the input action used here
public class FireButton : MonoBehaviour
{

    private PlayerShooting player;
    private bool pressed;
    private float timer = 0;
    
    [SerializeField]
    private float pressTime = 1; // time to press to trigger charged shot
    
    
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerShooting>();
        pressed = false;
    }

    
    public void OnPointerDown()
    {
        //Debug.Log("Button pressed");
        if ((player.currentStateName == "ChargedState"))
            FindObjectOfType<AudioManager>().Play("garGOyleCharging");
        pressed = true;
    }
    
    // When player leaves button, determine whether shoot default shot or charged shot
    public void OnPointerExit()
    {
        //Debug.Log("Button exit");
        pressed = false;
        //Debug.Log(timer);

        if ((timer > pressTime) && (player.currentStateName == "ChargedState"))
        {
            player.ammo = player.chargedFire;
            FindObjectOfType<AudioManager>().Play("garGOyleChargingDone");
        }
        player.fireFire();
        player.ammo = player.defaultFire;
        FindObjectOfType<AudioManager>().Stop("garGOyleCharging");
    }
    private void Update()
    {
        if (pressed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
    }
}
