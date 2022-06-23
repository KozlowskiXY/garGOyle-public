using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionParticle : MonoBehaviour
{

    

    private float m_xVel = 0;
    private float m_yVel = 0;
    public Transform tr;
    public Rigidbody rb;

    private void Start()
    {
        //tr.transform.localPosition += new Vector3(Random.Range(-15,15) * 0.1f ,0,0);
    }


    private void destroyIfOutOfScreen()
    {
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }

    }

    private void disableZChanges()
    {
        rb.velocity = new(m_xVel, m_yVel, 0);
        tr.position = new Vector3(tr.position.x, tr.position.y, 0);
    }

    private void disableRotation()
    {
        tr.transform.rotation = Quaternion.identity;
    }


    void Update()
    {
        m_xVel = rb.velocity.x;
        m_yVel = rb.velocity.y;

        destroyIfOutOfScreen();
        disableZChanges();
        disableRotation();

    }
}