using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//by Frieder

public class FireAreaAttack : MonoBehaviour
{
    //Access to all the children
    GameObject AOE_Marker;
    public GameObject FireSpotAttack;

    //Lifetime of this Object
    private float lifetime = 4f;
    //Already spawned Fire?
    private bool TriggerFire = true;

    private void Start()
    {
        try
        {
            AOE_Marker = transform.Find("AOE-Marker").gameObject;
        }
        catch
        {
            Debug.LogError("FireAreaAttack can't locate AOE-Marker");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
        if (lifetime <= 1.5 & TriggerFire)
        {
            TriggerFire = false;
            AOE_Marker.SetActive(false);
            Debug.Log("Firewall will be instantiated (TODO)");
            Instantiate(FireSpotAttack, gameObject.transform.position + new Vector3(0,30,0), Quaternion.Euler(90,0,0));
        }
    }
}
