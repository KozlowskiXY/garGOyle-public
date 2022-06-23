using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class TutorialState4 : TutorialBaseState
{
    private float timer = 10;
    public override void StateEnter(TutorialController tc)
    {
        tc.screen.SetActive(true);
        tc.textfield.text = "Manchmal fallen auch nützliche Dinge herunter.\n" +
                            "Zum Beispiel ein Herzchen.\n" +
                            "Sammle eines ein, falls du dich verletzt hast!\n" +
                            "Rechts oben siehst du deine Lebenspunkte, maximal 3.";
        tc.screen.GetComponent<TutorialInstanceScript>().Start();
        if(GameObject.FindObjectOfType<HealthBarController>().getHealth() == 3)
        {
            GameObject.FindObjectOfType<HealthBarController>().reduceHealth();
        }
        for(int i = 0; i <= 5; i++)
        {
            GameObject.Instantiate(tc.heart, new Vector3(25 + 10 * i, 70, 0), Quaternion.identity);
        }
    }

    public override void StateExit(TutorialController tc)
    {
        tc.tutorial_state = tc.tutorial_state_5;
        tc.tutorial_state.StateEnter(tc);
    }

    public override void StateUpdate(TutorialController tc)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            tc.tutorial_state.StateExit(tc);
        }
    }
}
