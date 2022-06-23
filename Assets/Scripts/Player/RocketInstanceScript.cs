using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handels the movement and end of life of the rocket object

public class RocketInstanceScript : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 0.03F;
    [SerializeField]
    private int height = 80;

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0, Time.deltaTime * movespeed, 0);
        this.transform.position += movement;
        if(transform.position.y > height)
        {
            Destroy(gameObject);
        }
    }
}
