using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class FalingStoneInstanceScript : FallingBaseInstanceScript
{
    [SerializeField]
    private GameObject explosion;
    //Collision and Destruction
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("GargoyleDeath");
        }

        if (collision.gameObject.layer == 8)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("GargoyleDeath");
        }
    }
}
