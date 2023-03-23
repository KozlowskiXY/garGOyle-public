using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel4 : BossTemplate
{
    public int collectSum = 10;
    public int collect = 0;
    public bool isShrinking;
    private void Start()
    {
        tr = this.transform;
        isShrinking = false;
    }
    
    /*public void shrink(string nextscene)
    {
        float scaleX = tr.localScale.x;
        if (scaleX <= 0f)
        {
            //SceneManager.LoadScene(nextscene);
        }
        //tr.localScale = tr.localScale * 0.98F;
        //tr.localScale *= 0.95f;
        tr.localScale.Scale(new Vector3(0.95f, 0.95f, 0.95f));
        Debug.Log(tr.localScale.x);
    } */
    
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
            wobble();
            shrink("CutScene4END");
        }
    }
}
