using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionInstanceScript : MonoBehaviour
{
    private float lifetime= 0;

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if(lifetime > 5)
        {
            Destroy(gameObject);
        }
    }
}
