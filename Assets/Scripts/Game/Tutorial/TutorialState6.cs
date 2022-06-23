using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class TutorialState6 : TutorialBaseState
{
    private GameObject miniboss;
    public override void StateEnter(TutorialController tc)
    {
        tc.screen.SetActive(true);
        tc.textfield.text = "In jedem Level triffst du auf einen Gargoyle-Boss.\n" +
                            "Ab dem zweiten Level musst du dem Boss Schaden mit deiner Spezialattacke machen um zu gewinnen.\n" +
                            "Halte den Feuerbutton länger gedrückt, um die Spezialattacke zu schießen.\n" +
                            "Um deine Spezialattacke aufzuladen, musst du etwas Besonderes einsammeln, das der Boss fallen lässt.\n" +
                            "Aber Achtung: der Boss lässt auch Wassertropfen, Holz und Steine fallen!";
        tc.screen.GetComponent<TutorialInstanceScript>().Start();
        miniboss = GameObject.Instantiate(tc.miniboss, new Vector3(50, 50, 0), Quaternion.identity);
    }

    public override void StateExit(TutorialController tc)
    {
        tc.tutorial_state = tc.tutorial_state_end;
        tc.tutorial_state.StateEnter(tc);
    }

    public override void StateUpdate(TutorialController tc)
    {
        if (miniboss.transform.localScale.x < 0.5f)
        {
            tc.tutorial_state.StateExit(tc);
        }
    }
}
