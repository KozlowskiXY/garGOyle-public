using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//by Frieder
public class MenuController : MonoBehaviour
{
    //=========================================================================
    //Level Selection
    public TextMeshProUGUI leveltext;
    public TextMeshProUGUI buttontext;
    public MenuBaseState state;
    public GameObject storage;
    public GameObject achievementscreen;
    public MenuTutorialLevelState tutorial = new();
    public MenuLevel1State level1 = new();
    public MenuLevel2State level2 = new();
    public MenuLevel3State level3 = new();

    public void LeftLevel()
    {
        state.LeftState(this);
        state.EnterState(this);
    }
    public void RightLevel()
    {
        state.RightState(this);
        state.EnterState(this);
    }
    public void EnterLevel()
    {
        state.EnterLevel(this);
    }
    //=========================================================================
    //Fixed methods for menu control flow
    public void ShowAchievements()
    {
        if(state == tutorial) {
            SceneManager.LoadScene("Credits");
        }
        else
        {
            achievementscreen.GetComponent<AchievementScreenController>().ShowAchievements(state.achievements_string);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene(sceneName: "CutScene1START1");
    }
    public void gameOverSceneSwitch()
    {
        SceneManager.LoadScene(sceneName: "Menu");
    }
    public void quitApplicationTrigger()
    {
        Application.Quit();
    }
    public void resumeGame()
    {
        switch (PlayerPrefs.GetInt("lastLevel", 1))
        {
            case 3:
                SceneManager.LoadScene("CutScene3START");
                break;
            case 2:
                SceneManager.LoadScene("CutScene2START");
                break;
            default:
                SceneManager.LoadScene("CutScene1START1");
                break;
        }
            
    }
    //*************************************************************************
    private void Start()
    {
        state = tutorial;
        state.EnterState(this);

    }
}
