using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//by Frieder
public class MenuLevel5State : MenuBaseState
{
    public override void RightState(MenuController menu)
    {

    }
    public override void LeftState(MenuController menu)
    {
        menu.state = menu.level4;
    }
    public override void EnterState(MenuController menu)
    {
        achievements = menu.storage.GetComponent<GamePreferencesController>().LoadAchievements(5);
        menu.leveltext.text = "Level 5";
        achievements_string = achievements.done ?
                                "Level 5 Erfolge:\n\n" +
                                (achievements.hurt ? "Beende das Level ohne Schaden zu nehmen!" : "Level beendet ohne Schaden zu nehmen.") + "\n\n" +
                                "Bestzeit: " + achievements.time + " Sekunden.\n\n" +
                                "Coins: " + achievements.coins + "/4\n" +
                                (achievements.coins > 0 ? "17. TODO" : "sammle 1 Münze um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 1 ? "18. TODO" : "sammle 2 Münzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 2 ? "19. TODO" : "sammle 3 Münzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 3 ? "20. TODO" : "sammle 4 Münzen um diesen Erfolg freizuschalten!")
                                :
                                "Beende Level 5, um die Erfolge freizuschalten!";
    }
    public override void EnterLevel(MenuController menu)
    {
        SceneManager.LoadScene("CutScene5Start");
    }
}
