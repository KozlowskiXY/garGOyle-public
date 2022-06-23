using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//by Frieder
public class MenuTutorialLevelState : MenuBaseState
{
    public override void RightState(MenuController menu)
    {
        menu.state = menu.level1;
    }
    public override void LeftState(MenuController menu)
    {
        
    }
    public override void EnterState(MenuController menu)
    {
        menu.buttontext.text = "Credits";
        menu.leveltext.text = "Tutorial";
    }

    public override void EnterLevel(MenuController menu)
    {
        SceneManager.LoadScene("TutorialLevel");
    }
}
