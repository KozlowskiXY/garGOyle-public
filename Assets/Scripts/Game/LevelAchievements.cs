using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class LevelAchievements
{
    public int coins;
    public int time;
    public bool hurt;
    public bool done;

    public static LevelAchievements MakeLevelAchievements(int coins, bool hurt, int time)
    {
        LevelAchievements achievements = new LevelAchievements();
        achievements.hurt = hurt;
        achievements.coins = coins;
        achievements.time = time;
        achievements.done = true;
        return achievements;
    }
    public static LevelAchievements MakeLevelAchievements()
    {
        LevelAchievements achievements = new LevelAchievements();
        achievements.done = false;
        return achievements;
    }
}
