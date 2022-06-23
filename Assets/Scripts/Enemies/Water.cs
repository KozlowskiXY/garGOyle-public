//by Samuel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Water : MonoBehaviour
{
    private float m_x = 0.6f;
    private float m_y = 0.6f;
    private float m_xVel = 0;
    private float m_yVel = 0;
    private float m_wobbleTime = 0;

    private bool isInWaterBar = false;

    private float m_randomY = 0;
    private float m_randomX = 0;

    public Transform tr;
    public Rigidbody rb;

    private void wobble()
    {
        tr.localScale = new Vector3(m_x + 0.25f * Mathf.Abs(Mathf.Sin(m_wobbleTime * 6f)),
                                    m_y + 0.25f * Mathf.Abs(Mathf.Sin(m_wobbleTime * 8f)),
                                    0);
    }

    private void Start()
    {
        Physics.IgnoreLayerCollision(4, 4);   //water particle ignors its own phisics outside waterbar
        Physics.IgnoreLayerCollision(14, 14); //water particle ignors its own phisics inside waterbar
        Physics.IgnoreLayerCollision(14, 6);  ////water particle ignors asteroid phisics inside waterbar
    }

    private void destroyIfToFast()
    {
        if (Mathf.Abs(rb.velocity.x) > 50 || Mathf.Abs(rb.velocity.y) > 50)
            Destroy(gameObject);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            m_randomX = Random.Range(-0.25f, 0.5f);
            m_randomY = 24 + Random.Range(-4f, 0f);
            tr.position = new(GameObject.FindObjectOfType<WaterContainerBottom>().transform.position.x + m_randomX,
                              GameObject.FindObjectOfType<WaterContainerBottom>().transform.position.y + m_randomY,
                              0);
            rb.velocity = new(0, 0, 0);
            isInWaterBar = true;
            gameObject.layer = 14;
            collision.gameObject.GetComponent<Player>().playEatingSound();
        }

        if (collision.gameObject.layer == 12)
        {
            if (isInWaterBar)
            {
                
                collision.gameObject.GetComponent<WaterBar>().grow();
            }

            Destroy(gameObject);
        }
    }
    void Update()
    {
        m_wobbleTime += Time.deltaTime;
        m_xVel = rb.velocity.x;
        m_yVel = rb.velocity.y;
        //wobble(); due to color issues not enabled
        destroyIfToFast();
        destroyIfOutOfScreen();
        disableZChanges();
        disableRotation();

    }
}
