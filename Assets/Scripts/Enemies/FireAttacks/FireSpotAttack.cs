using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpotAttack : MonoBehaviour
{
    private bool hurt = false;
    private float lifetime = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(!hurt)
            {
                FindObjectOfType<HealthBarController>().reduceHealth();
                hurt = true;
                StartCoroutine(collision.gameObject.GetComponent<Player>().hitCooldownVis());               
            }
        }
    }
}
