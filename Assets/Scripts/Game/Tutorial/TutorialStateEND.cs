using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialStateEND : TutorialBaseState
{
    private float timer = 0.01f;
    public override void StateEnter(TutorialController tc)
    {
        tc.screen.SetActive(true);
        tc.textfield.text = "Du hast das Tutorial erfolgreich abgeschlossen." +
                            "Viel Spaß beim Spielen!";
        tc.screen.GetComponent<TutorialInstanceScript>().Start();
    }

    public override void StateExit(TutorialController tc){
        SceneManager.LoadScene("Menu");
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
