using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingMinibossPickupInstanceScript : FallingBaseInstanceScript
{
    private WaterBar waterbar;
    protected void Start()
    {
        base.Start();
        waterbar = GameObject.Find("WaterBar").GetComponent<WaterBar>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 0)
        {
            waterbar.setMaxWaterLevel();
            Destroy(gameObject);
        }
    }
}
