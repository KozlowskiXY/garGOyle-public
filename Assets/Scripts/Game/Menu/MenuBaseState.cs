using UnityEngine;
using UnityEngine.SceneManagement;
//by Frieder
public abstract class MenuBaseState
{
    public abstract void RightState(MenuController menu);

    public abstract void LeftState(MenuController menu);

    public abstract void EnterState(MenuController menu);

    public abstract void EnterLevel(MenuController menu);

    public LevelAchievements achievements;
    public string achievements_string;
}
