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

    public InputActionReference actionFire;

    [SerializeField]
    private float pressTime = 1; // time to press to trigger charged shot

    private void OnEnable()
    {
        actionFire.action.Enable();
    }
    private void OnDisable()
    {
        actionFire.action.Disable();
    }

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerShooting>();
        pressed = false;
        actionFire.action.started += context =>
        {
            if ((player.currentStateName == "ChargedState"))
                FindObjectOfType<AudioManager>().Play("garGOyleCharging");
            pressed = true;
        };
        actionFire.action.canceled += context =>
        {
            pressed = false;

            if ((timer > pressTime) && (player.currentStateName == "ChargedState"))
            {
                player.ammo = player.chargedFire;
                FindObjectOfType<AudioManager>().Play("garGOyleChargingDone");
            }
            player.fireFire();
            player.ammo = player.defaultFire;
            FindObjectOfType<AudioManager>().Stop("garGOyleCharging");
        };
    }

    
    public void OnPointerDown()
    {
        if ((player.currentStateName == "ChargedState"))
            FindObjectOfType<AudioManager>().Play("garGOyleCharging");
        pressed = true;
    }

    
    // When player leaves button, determine whether shoot default shot or charged shot
    public void OnPointerExit()
    {
        pressed = false;

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
