using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFlightScript : MonoBehaviour
{
    //This handels switching the 3 sprites of the flying animation
    public Sprite WingsUP;
    public Sprite WingsMID1;
    public Sprite WingsMID2;
    public Sprite WingsDOWN;
    private SpriteRenderer render;
    private float flighttimer = 0;

    private void PlayerFlight()
    {
        flighttimer = (flighttimer + Time.deltaTime) % 1;
        if (flighttimer < 0.2)
        {
            render.sprite = WingsDOWN;
        }
        else if (flighttimer < 0.35)
        {
            render.sprite = WingsMID1;
        }
        else if (flighttimer < 0.5)
        {
            render.sprite = WingsMID2;
        }
        else if (flighttimer < 0.65)
        {
            render.sprite = WingsUP;
        }
        else if (flighttimer < 0.8)
        {
            render.sprite = WingsMID2;
        }
        else if (flighttimer < 0.9)
        {
            render.sprite = WingsMID1;
        }
    }
    private void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        PlayerFlight();
    }
}
