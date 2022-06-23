using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder
public class FallingBaseInstanceScript : MonoBehaviour
{
    
    private float speedIncrease = -8F;
    protected Rigidbody rb;

    // Update is called once per frame

    protected void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected float timeSinceLastHit = 0;

    void Update()
    {
        rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + speedIncrease * Time.deltaTime, 0);
        rb.velocity = new Vector3(0, 0, 0);
        timeSinceLastHit = Time.deltaTime;
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
}
