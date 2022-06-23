using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class TutorialState3 : TutorialBaseState
{
    private float timer = 10;
    public override void StateEnter(TutorialController tc)
    {
        tc.screen.SetActive(true);
        tc.textfield.text = "Außerdem werfen die Gargoyles  auch Holz und Steine herab.\n" +
                            "Holz ist stabil. Deswegen muss man es zweimal abschießen.\n" +
                            "Steine können nicht mit Feuerbällen zerstört werden.\n" +
                            "Weiche ihnen immer aus!";
        tc.screen.GetComponent<TutorialInstanceScript>().Start();
        for(int i = 0; i <= 10; i++)
        {
            if( i % 2 == 0)
                GameObject.Instantiate(tc.wood, new Vector3(10 * i, 70, 0), Quaternion.identity);
            else
                GameObject.Instantiate(tc.stone, new Vector3(10 * i, 70, 0), Quaternion.identity);
        }
    }

    public override void StateExit(TutorialController tc)
    {
        tc.tutorial_state = tc.tutorial_state_4;
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
