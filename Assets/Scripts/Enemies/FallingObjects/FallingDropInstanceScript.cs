using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class FallingDropInstanceScript : FallingBaseInstanceScript
{
    [SerializeField]
    private GameObject explosion;

    //Collision and Destruction
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("garGOyleHitWater");
        }

        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 17)
        {
            if(collision.gameObject.layer == 17) playMoneyCollisionSound();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("garGOyleHitWater");
        }
    }

    
    void playMoneyCollisionSound()
    {
        if (timeSinceLastHit < 0.5f)
        {
            FindObjectOfType<AudioManager>().Play("garGOyleMoneyBagHit" + UnityEngine.Random.Range(1, 3));
            timeSinceLastHit = 0;
        }
    }

}