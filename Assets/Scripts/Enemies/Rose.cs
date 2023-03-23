using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* A Rose can be thrown by boss. It has a charming area around his center
   to move the player towards itself. When the player collects a rose,
   certain effects can occur (in this version only changes in velocity)
*/
public class Rose : MonoBehaviour
{
    private GameObject player;
    private float playerSpeed;
    // effects only last a limited time on player
    [SerializeField]
    private float effectTime = 5.0f;
    // measure time of effect
    private float timer = 0;
    // needed to calculate new player position
    private Vector3 playerPos;
    private Vector3 rosePos;
    
    
    // number of roses to be collected to succeed
    private int collectSum;
    private GameObject boss;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        boss = GameObject.Find("BossLevel4");
        if (player != null)
        {
            playerSpeed = player.GetComponent<Player>().speedfaktor;
        }
        else
        {
            Debug.Log("Player not found. Sth is not right..");
            Destroy(gameObject);
        }

        FindObjectOfType<AudioManager>().applyDistortion();
        
    }
    
    // test whether player is in charming area given by circle of radius r
    bool isPlayerClose(float r)
    {
        Vector3 center = gameObject.transform.position;
        Vector3 playerPos = player.transform.position;
        //float dot = Vector3.Dot(playerPos - center, playerPos - center);

        Vector2 center2d = new Vector2(center.x, center.y);
        Vector2 playerPos2d = new Vector2(playerPos.x, playerPos.y);
        float dot = Vector2.Dot(playerPos2d - center2d, playerPos2d - center2d);

        return dot <= r * r;
    }

    // reset speed effect. also template for other possible temp effects that should
    // be stopped
    void resetSpeed()
    {
        if (timer > effectTime)
        {
            player.GetComponent<Player>().speedfaktor = playerSpeed;
            timer = 0;
        }
    }

    public void defeatBoss()
    {
        boss.gameObject.GetComponent<BossLevel4>().isAlive = false;
    }

    // Add effect once player hits rose
    private void OnCollisionEnter(Collision collision)
    {   
        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<WaterBar>().growWaterLevelBy(5);
            player.GetComponent<Player>().speedfaktor *= 0.4f;
            player.GetComponent<Player>().effectStart = true;
            boss.GetComponent<BossLevel4>().collect++;
            if (boss.GetComponent<BossLevel4>().collect ==
                boss.gameObject.GetComponent<BossLevel4>().collectSum)
            {
                defeatBoss();
            }
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().removeDistortion();
        }
    }

    private Vector3 charmVec;
    private float diffLen;
    void Update()
    {
        // Tear player torwards rose. Actual circle size may be changed
        rosePos = gameObject.transform.position;
        if (isPlayerClose(20.0f))
        {
            playerPos = player.transform.position;
            diffLen = (rosePos - playerPos).magnitude;
            charmVec = new Vector3(
                (20.0f / diffLen) * (rosePos - playerPos).x,
                (1.0f / 5.0f) * (rosePos - playerPos).y,
                (rosePos - playerPos).z
            );
            
            playerPos = playerPos +
                        (Time.deltaTime * charmVec);
            player.GetComponent<Transform>().position = playerPos;
        }
        if (rosePos.y < -10)
        {
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().removeDistortion();
        }
    }
}
