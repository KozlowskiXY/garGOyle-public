using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class BossLevel1 : BossTemplate
{
    
    private void Update()
    {

        timeManager();
        if (isAlive)
        {
            wobble();
            stoneAttack();
        }
        else
        {
            shrink("CutScene1END");
        }
    }
}