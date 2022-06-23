using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//by Frieder
public class GamePreferencesController : MonoBehaviour
{
    // Load and save on Start and quit
    void Start()
    {
        LoadPrefs();
    }
    private void OnApplicationQuit()
    {
        if (!(SceneManager.GetActiveScene().name == "Menu"))
        {
            SavePrefs();
        }
    }
    private void OnDestroy()
    {
        if (!(SceneManager.GetActiveScene().name == "Menu"))
        {
            SavePrefs();
        }
    }
    //Load and Save max and current level
    public void SavePrefs()
    {
        //First Attempt at Automation, might be better to hardcode the names to numbers
        PlayerPrefs.SetInt("lastLevel", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("maxLevel", Math.Max(SceneManager.GetActiveScene().buildIndex, PlayerPrefs.GetInt("maxLevel")));
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        var lastLevel = PlayerPrefs.GetInt("lastLevel", 1);
        var maxLevel  = PlayerPrefs.GetInt("maxLevel", 1);
        //Add Code to set the Values here

    }
    //Save achievements
    public void SaveAchievements(int level, int coins, bool hurt, int time)
    {
        Debug.Log("Save Level" + level + ", with " + coins + " coins, " + (hurt ? "verletzt, " : "unverletzt, ") + "Zeit: " + time);
        PlayerPrefs.SetInt("level" + level + "done", 1);
        PlayerPrefs.SetInt("level" + level + "coins", Math.Max(coins, PlayerPrefs.GetInt("level" + level + "coins", 0)));
        PlayerPrefs.SetInt("level" + level + "hurt", hurt ? PlayerPrefs.GetInt("level" + level + "hurt", 1) : 0);
        PlayerPrefs.SetInt("level" + level + "time", Math.Min(time, PlayerPrefs.GetInt("level" + level + "time", 9999)));
    }
    //Load achievements
    public LevelAchievements LoadAchievements(int level)
    {
        if(PlayerPrefs.GetInt("level" + level + "done", 0) == 1)
        {
            int coins = PlayerPrefs.GetInt("level" + level + "coins", 0);
            int time = PlayerPrefs.GetInt("level" + level + "time");
            bool hurt = 1 == PlayerPrefs.GetInt("level" + level + "hurt", 1);
            LevelAchievements achievements = LevelAchievements.MakeLevelAchievements(coins, hurt, time);
            return achievements;
        }
        else
        {
            return LevelAchievements.MakeLevelAchievements();
        }
    }
}
