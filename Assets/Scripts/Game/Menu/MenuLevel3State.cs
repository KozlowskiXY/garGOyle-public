using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//by Frieder, facts by Julia
public class MenuLevel3State : MenuBaseState
{
    public override void RightState(MenuController menu)
    {

    }
    public override void LeftState(MenuController menu)
    {
        menu.state = menu.level2;
    }
    public override void EnterState(MenuController menu)
    {
        achievements = menu.storage.GetComponent<GamePreferencesController>().LoadAchievements(3);
        menu.leveltext.text = "Level 3";
        achievements_string = achievements.done ?
                                "Level 3 Erfolge:\n\n" +
                                (achievements.hurt ? "Beende das Level ohne Schaden zu nehmen!" : "Level beendet ohne Schaden zu nehmen.") + "\n\n" +
                                "Bestzeit: " + achievements.time + " Sekunden.\n\n" +
                                "Coins: " + achievements.coins + "/4\n" +
                                (achievements.coins > 0 ? "9. Der Glockenturm hat 153 Stufen." : "sammle 1 M�nze um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 1 ? "10. Das Ger�st, an dem die Glocken h�ngen, nennt man Glockenstuhl." : "sammle 2 M�nzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 2 ? "11. Glocken sind schwer. Deswegen muss der Glockenstuhl viel tragen k�nnen. Der Glockenstuhl des M�nsters k�nnte mehr als 40 Elefanten tragen." : "sammle 3 M�nzen um diesen Erfolg freizuschalten!") + "\n\n" +
                                (achievements.coins > 3 ? "12. Du musst ein echter Fan sein. Danke f�rs spielen =)" : "sammle 4 M�nzen um diesen Erfolg freizuschalten!")
                                :
                                "Beende Level 3, um die Erfolge freizuschalten!";
    }
    public override void EnterLevel(MenuController menu)
    {
        SceneManager.LoadScene("CutScene3Start");
    }
}
