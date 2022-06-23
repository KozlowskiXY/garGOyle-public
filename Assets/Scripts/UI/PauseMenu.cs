using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
//by Frieder
public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject joystick;
    [SerializeField]
    GameObject firebutton;
    [SerializeField]
    GameObject pausebutton;
    [SerializeField]
    GameObject storage;
    
    public void PauseTheGame()
    {
        gameObject.SetActive(true);
        joystick.SetActive(false);
        firebutton.SetActive(false);
        pausebutton.SetActive(false);
        Time.timeScale = 0.0f;
    }
    public void ResumeTheGame()
    {
        gameObject.SetActive(false);
        joystick.SetActive(true);
        firebutton.SetActive(true);
        pausebutton.SetActive(true);
        Time.timeScale = 1.0f;
    }

    public void QuitToMainMenu()
    {
        storage.GetComponent<GamePreferencesController>().SavePrefs();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Menu");
    }

    //*************************************************************************
    void Start()
    {
        gameObject.SetActive(false);
    }
}
