using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class TutorialState5 : TutorialBaseState
{
    private float timer = 10;
    public override void StateEnter(TutorialController tc)
    {
        tc.screen.SetActive(true);
        tc.textfield.text = "In jedem Level gibt es 4 Münzen, die du sammeln kannst.\n" +
                            "Sammle sie ein, um Erfolge freizuschalten!\n" +
                            "Im Menu kannst du sehen, was du damit freigeschaltet hast.";
        tc.screen.GetComponent<TutorialInstanceScript>().Start();
        for(int i = 0; i < 4; i++)
        {
            GameObject.Instantiate(tc.coin, new Vector3(35 + 10 * i, 70, 0), Quaternion.identity);
        }
    }

    public override void StateExit(TutorialController tc)
    {
        tc.tutorial_state = tc.tutorial_state_6;
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
