using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class FallingWoodInstanceScript : FallingBaseInstanceScript
{

    [SerializeField]
    private GameObject explosion;
    [SerializeField]
    private GameObject fire;
    private int lifes = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        fire.GetComponent<ParticleSystem>().Stop();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 17)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            if (collision.gameObject.layer == 17) playMoneyCollisionSound();
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("GargoyleDeath");
        }

        if (collision.gameObject.layer == 7)
        {

            Instantiate(explosion, transform.position, Quaternion.identity);
            lifes--;
            if(lifes == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                fire.GetComponent<ParticleSystem>().Play();
            }
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("GargoyleDeath");
        }

    }

    void playMoneyCollisionSound()
    {
        if (timeSinceLastHit < 0.5f)
        {
            FindObjectOfType<AudioManager>().Play("garGOyleMoneyBagHit" + Random.Range(1, 3));
            timeSinceLastHit = 0;
        }
    }
}
