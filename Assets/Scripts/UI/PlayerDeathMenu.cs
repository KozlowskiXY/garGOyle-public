using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
//by Frieder
public class PlayerDeathMenu : MonoBehaviour
{
    [SerializeField]
    GameObject joystick;
    [SerializeField]
    GameObject firebutton;
    [SerializeField]
    GameObject pausebutton;
    [SerializeField]
    GameObject storage;
    public Button SelectButton;
    
    public void GameOver()
    {
        gameObject.SetActive(true);
        joystick.SetActive(false);
        firebutton.SetActive(false);
        pausebutton.SetActive(false);
        Time.timeScale = 0.0f;
        SelectButton.Select();
    }
    public void TryAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneBuildIndex: scene.buildIndex);
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
