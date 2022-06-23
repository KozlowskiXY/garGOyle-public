using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsBack2Menu : MonoBehaviour
{
    private void Start()
    {
    }

    public void back2Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
}
