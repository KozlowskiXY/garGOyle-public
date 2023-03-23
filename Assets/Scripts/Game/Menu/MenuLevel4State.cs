using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//by Frieder
public class MenuLevel4State : MenuBaseState
{
    public override void RightState(MenuController menu)
    {
        menu.state = menu.level5;
    }
    public override void LeftState(MenuController menu)
    {
        menu.state = menu.level3;
    }
    public override void EnterState(MenuController menu)
    {
        achievements = menu.storage.GetComponent<GamePreferencesController>().LoadAchievements(4);
        menu.leveltext.text = "Level 4";
        achievements_string = achievements.done ?
                                "Level 4 Erfolge:\n\n" +
                                (achievements.hurt ? "Beende das Level ohne Schaden zu nehmen!" : "Level beendet ohne Schaden zu nehmen.") + "\n\n" +
                                "Bestzeit: " + achievements.time + " Sekunden.\n\n" +
                                "Coins: " + achievements.coins + "/4\n" +
                                (achievements.coins > 0 ? "13. TODO" : "sammle 1 Münze um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 1 ? "14. TODO" : "sammle 2 Münzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 2 ? "15. TODO" : "sammle 3 Münzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 3 ? "16. TODO" : "sammle 4 Münzen um diesen Erfolg freizuschalten!")
                                :
                                "Beende Level 4, um die Erfolge freizuschalten!";
    }
    public override void EnterLevel(MenuController menu)
    {
        SceneManager.LoadScene("CutScene4Start");
    }
}
