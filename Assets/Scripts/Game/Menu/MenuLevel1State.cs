using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//by Frieder, facts by Julia
public class MenuLevel1State : MenuBaseState
{
    public override void RightState(MenuController menu)
    {
        menu.state = menu.level2;
    }
    public override void LeftState(MenuController menu)
    {
        menu.state = menu.tutorial;
    }
    public override void EnterState(MenuController menu)
    {
        achievements = menu.storage.GetComponent<GamePreferencesController>().LoadAchievements(1);
        menu.leveltext.text = "Level 1";
        menu.buttontext.text = "Erfolge";
        achievements_string = achievements.done ?
                                "Level 1 Erfolge:\n\n" +
                                (achievements.hurt ? "Beende das Level ohne Schaden zu nehmen!" : "Level beendet ohne Schaden zu nehmen.") + "\n\n" +
                                "Coins: " + achievements.coins + "/4\n" +
                                (achievements.coins > 0 ? "1. Das Freiburger M�nster ist �ber 900 Jahre alt." : "sammle 1 M�nze um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 1 ? "2. Es hat etwa 300 Jahre gedauert, das M�nster zu bauen." : "sammle 2 M�nzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 2 ? "3. Das Freiburger M�nster hei�t �Unserer lieben Frau�. Damit ist die Mutter von Jesus gemeint. Die Mutter von Jesus hei�t Maria." : "sammle 3 M�nzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 3 ? "4. Das Freiburger M�nster ist die Kirche des Bischofs von Freiburg. Ein Bischof ist ein wichtiger Mann in der katholischen Kirche." : "sammle 4 M�nzen um diesen Erfolg freizuschalten!")
                                :
                                "Beende Level 1, um die Erfolge freizuschalten!";
    }
    public override void EnterLevel(MenuController menu)
    {
        SceneManager.LoadScene("CutScene1Start1");
    }
}
