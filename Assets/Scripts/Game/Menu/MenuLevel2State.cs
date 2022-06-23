using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//by Frieder, facts by Julia
public class MenuLevel2State : MenuBaseState
{
    public override void RightState(MenuController menu)
    {
        menu.state = menu.level3;
    }
    public override void LeftState(MenuController menu)
    {
        menu.state = menu.level1;
    }
    public override void EnterState(MenuController menu)
    {
        achievements = menu.storage.GetComponent<GamePreferencesController>().LoadAchievements(2);
        menu.leveltext.text = "Level 2";
        achievements_string = achievements.done ?
                                "Level 2 Erfolge:\n\n"+
                                (achievements.hurt ? "Beende das Level ohne Schaden zu nehmen!" : "Level beendet ohne Schaden zu nehmen.") + "\n\n" +
                                "Bestzeit: " + achievements.time + " Sekunden.\n\n" +
                                "Coins: " + achievements.coins + "/4\n" +
                                (achievements.coins > 0 ? "5. Das Münster besteht aus Buntsandstein. Dieser stammt aus der Nähe von Freiburg." : "sammle 1 Münze um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 1 ? "6. Auch Steine altern. Deswegen muss man sie schützen und pflegen. Dafür sind die Denkmalpflege und die Münsterbauhütte zuständig." : "sammle 2 Münzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 2 ? "7. Die meisten der bunten Fenster im Münster sind schon 700 bis 800 Jahre alt." : "sammle 3 Münzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 3 ? "8. Bevor man das Münster betritt, steht man in der Vorhalle. Die Figuren an den Wänden dort zeigen, wie man sich den Himmel und die Hölle vor 700 Jahren vorgestellt hat." : "sammle 4 Münzen um diesen Erfolg freizuschalten!")
                                :
                                "Beende Level 2, um die Erfolge freizuschalten!";
    }
    public override void EnterLevel(MenuController menu)
    {
        SceneManager.LoadScene("CutScene2Start");
    }
}
