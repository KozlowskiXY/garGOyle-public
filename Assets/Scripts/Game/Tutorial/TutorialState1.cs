using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class TutorialState1 : TutorialBaseState
{
    private GameObject player;
    private Vector3 posn;
    private bool shot_fired = false;
    private bool done = false;
    private float countdown = 1.5f;
    public override void StateEnter(TutorialController tc)
    {
        tc.textfield.text = "Nutze den Stick auf der rechten Seite, um Sammy zu steuern.\n" +
                            "Schieße Feuerbälle mit dem Feuerbutton auf der linken Seite.";
        tc.screen.GetComponent<TutorialInstanceScript>().Start();
        player = GameObject.FindWithTag("Player");
        posn = player.transform.position;
    }

    public override void StateExit(TutorialController tc)
    {
        tc.tutorial_state = tc.tutorial_state_2;
        tc.tutorial_state.StateEnter(tc);
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Rocket"))
        {
            GameObject.Destroy(obj);
        }
    }

    public override void StateUpdate(TutorialController tc)
    {
        if(GameObject.FindObjectOfType<RocketInstanceScript>() != null)
        {
            shot_fired = true;
        }
        if(shot_fired && Vector3.Distance(posn, player.transform.position) > 15)
        {
            done = true;
        }
        if (done)
        {
            countdown -= Time.deltaTime;
        }
        if( countdown < 0)
        {
            tc.tutorial_state.StateExit(tc);
        }
    }
}
