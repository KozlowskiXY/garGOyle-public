using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Displays Button when level is going to end and defeats the endboss
public class BossDefeatButton : MonoBehaviour
{
    // Change to actual time the level should take
    [SerializeField]
    private float levelTime = 90F;
    
    [SerializeField]
    private GameObject button;

    [SerializeField]
    private GameObject spawner;
    
    [SerializeField]
    private BossLevel1 endbossScript;
    
    
   
    void Start()
    {
        button.SetActive(false);
        StartCoroutine(displayEndButton(true, levelTime));
    }
    

    // Enable or disable boss defeat button after time seconds
    IEnumerator displayEndButton(bool disp, float time)
    {
        yield return new WaitForSeconds(time);
        button.SetActive(disp);
        button.GetComponent<Button>().Select();
    }
    
    // Starts event that eliminates the Endboss
    public void endBossFight()
    {
        spawner.SetActive(false); //!!!!! set spawner active at beginning
        endbossScript.isAlive = false;
        StartCoroutine(displayEndButton(false, 1.5F));
        /*####
         implement change to different scene at this point
         ####*/
        
    }
    
}
