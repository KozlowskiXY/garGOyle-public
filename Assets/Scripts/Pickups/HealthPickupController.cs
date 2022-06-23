using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupController : MonoBehaviour
{
    private HealthBarController healthbar;
    
    void Start()
    {
        healthbar = FindObjectOfType<HealthBarController>();
    }

    // On collision, call restore health function in player script
}