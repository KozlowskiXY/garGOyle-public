using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossHealthbar : MonoBehaviour
{
    [SerializeField]
    private GameObject boss;

    private BossTemplate bossScript;
    private int lives;
    
    private Text textComp;
    private string level;
    void Start()
    {
        textComp = this.GetComponent<Text>();
        level = SceneManager.GetActiveScene().name;
        if (level == "Level2")
        {
            bossScript = boss.GetComponent<BossLevel2>();
            lives = boss.GetComponent<BossLevel2>().lives;
        }
        else if (level == "Level3")
        {
            bossScript = boss.GetComponent<BossLevel3>();
            lives = boss.GetComponent<BossLevel3>().lives;
        }
        else if (level == "Level5")
        {
            bossScript = boss.GetComponent<BossLevel5>();
            lives = boss.GetComponent<BossLevel5>().lives;
        }
        else if (level == "Level4")
        {
            bossScript = boss.GetComponent<BossLevel4>();
            lives = boss.GetComponent<BossLevel4>().collect;
        }
    }
    
    void displayLives()
    {
        if (bossScript.isAlive)
            if (level != "Level4")
            {
                textComp.text = String.Format("Boss Leben: {0}/{1}", lives+1, 4);
            }
            else
            {
                textComp.text = String.Format("Rosen: {0}/{1}", lives, 10);
            }
        else
            textComp.text = "";
    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (level == "Level2")
        {
            lives = boss.GetComponent<BossLevel2>().lives;
        }
        else if (level == "Level5")
        {
            lives = boss.GetComponent<BossLevel5>().lives;
        }
        else if (level == "Level3")
        {
            lives = boss.GetComponent<BossLevel3>().lives;
        }
        else
        {
            lives = boss.GetComponent<BossLevel4>().collect;
        }
        displayLives();
    }
}
