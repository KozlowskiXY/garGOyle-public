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
    void Start()
    {
        textComp = this.GetComponent<Text>();
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            bossScript = boss.GetComponent<BossLevel2>();
            lives = boss.GetComponent<BossLevel2>().lives;
        }

        else
        {
            bossScript = boss.GetComponent<BossLevel3>();
            lives = boss.GetComponent<BossLevel3>().lives;
        }
            
    }
    
    void displayLives()
    {
        if (bossScript.isAlive)
            textComp.text = String.Format("Boss Leben: {0}/{1}", lives+1, 4);
        else
            textComp.text = "";
    }

    
    // Update is called once per frame
    void Update()
    {
        
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            lives = boss.GetComponent<BossLevel2>().lives;
        }

        else
        {
            
            lives = boss.GetComponent<BossLevel3>().lives;
        }
        displayLives();
    }
}
