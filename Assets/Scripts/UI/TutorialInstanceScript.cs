using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class TutorialInstanceScript : MonoBehaviour
{
    public GameObject[] cameras;
    public void Start()
    {
        Time.timeScale = 0f;
        foreach(GameObject cam in cameras)
        {
            cam.SetActive(false);
        }
    }
    public void EndTutorial()
    {
        foreach (GameObject cam in cameras)
        {
            cam.SetActive(true);
        }
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
