using System;
using UnityEngine;
//by Frieder
public class FallingCoinInstanceScript : FallingBaseInstanceScript
{
    private AchievementCollectorController achievement_controller;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        achievement_controller = FindObjectOfType<AchievementCollectorController>();
    }
     
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            try
            {
                achievement_controller.CollectCoin();
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
            FindObjectOfType<AudioManager>().Play("garGOyleCollectHeart");
            Destroy(gameObject);
        }
    }
}
