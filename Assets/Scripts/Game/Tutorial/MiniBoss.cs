using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class MiniBoss : MonoBehaviour
{
    public GameObject shot;
    public GameObject waterdrop;

    public bool alive = true;
    private float timer_asteroid = 5;
    private float timer_shot = 3;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("other: " + other.gameObject.layer);
        if (other.gameObject.layer == 8)
        {
            alive = false;
            GetComponentInChildren<SpriteRenderer>().color = Color.red;
        }
    }


    void Update()
    {
        timer_asteroid -= Time.deltaTime;
        timer_shot -= Time.deltaTime;
        if(timer_shot < 0)
        {
            Instantiate(shot, new Vector3(transform.position.x, transform.position.y - 3, 0), Quaternion.identity);
            timer_shot = 5;
        }
        if (timer_asteroid < 0)
        {
            Instantiate(waterdrop, new Vector3(transform.position.x, transform.position.y - 3, 0), Quaternion.identity);
            timer_asteroid = 5;
        }
        if (!alive)
        {
            transform.localScale *= 0.98f;
        }
    }
}
