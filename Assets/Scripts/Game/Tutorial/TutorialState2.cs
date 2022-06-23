using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class TutorialState2 : TutorialBaseState
{
    private float timer = 10;
    private GameObject[] drops = new GameObject[11];
    public override void StateEnter(TutorialController tc)
    {
        tc.screen.SetActive(true);
        tc.textfield.text = "Im Level werfen die Gargoyles  Wassertropfen herab.\n" +
                            "Weiche ihnen aus oder zerstöre sie mit Feuerbällen!";
        tc.screen.GetComponent<TutorialInstanceScript>().Start();
        for (int i = 0; i < 11; i++)
        {
            drops[i] = GameObject.Instantiate(tc.waterdrop, new Vector3(10* i, 70, 0), Quaternion.identity);
        }
    }

    public override void StateExit(TutorialController tc)
    {
        foreach(GameObject drop in drops)
        {
            GameObject.Destroy(drop);
        }
        tc.tutorial_state = tc.tutorial_state_3;
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
