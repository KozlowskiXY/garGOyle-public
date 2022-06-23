using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder

public class AchievementCollectorController : MonoBehaviour
{
    public GameObject healthbar;
    public GameObject boss;
    public GameObject gamepreferencescontroller;
    private int coins = 0;
    private int level;
    private bool alive;
    private bool hurt = false;
    private float time = 0f;

    public void CollectCoin()
    {
        coins++;
    }

    private void Update()
    {
        time += Time.deltaTime;
        try
        {
            //get Player hurt status
            if (!hurt)
            {
                hurt = healthbar.GetComponent<HealthBarController>().lostLives > 0;
            }           

            //Get Boss alive status (sucessfull level completion?)
            if (boss.GetComponent<BossLevel1>() != null)
            {
                alive = boss.GetComponent<BossLevel1>().isAlive;
                level = 1;
            }
            else if (boss.GetComponent<BossLevel2>() != null)
            {
                alive = boss.GetComponent<BossLevel2>().isAlive;
                level = 2;
            }
            else if(boss.GetComponent<BossLevel3>() != null)
            {
                alive = boss.GetComponent<BossLevel3>().isAlive;
                level = 3;
            }
            else
            {
                Debug.LogError("Connect Boss to AchievementCollector");
            }
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
        }
        //If Boss is dead store Achievements
        if (!alive)
        {
            try
            {
                gamepreferencescontroller.GetComponent<GamePreferencesController>().SaveAchievements(level, coins, hurt, (int)time);
                Destroy(gameObject);
            }
            catch (NullReferenceException)
            {
                Debug.LogError("Connect PlayerPrefs object to AchievementCollector");
            }
        }
    }
}
