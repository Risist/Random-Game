﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuPanelUIDisplayer : MonoBehaviour {

    // Variable for checking if game is paused
    [SerializeField]
    public static bool IsGamePaused = false;
    TogglePanel panel;
    public GameObject mainMenuUI;
    public GameObject optionsMenuUI;

    private void Awake()
    {
        panel = gameObject.GetComponent<TogglePanel>();
    }

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsGamePaused)
            {
                panel.Paneltoggle(mainMenuUI);
                Pause();

            }
            else
            {
                panel.Paneltoggle(mainMenuUI);
                Resume();
            }
        }
        else
        {
            if (mainMenuUI.activeSelf || optionsMenuUI.activeSelf)
                Pause();
            else
                Resume();
        }
    }

    void Resume()
    {
        //mainMenuUI.SetActive(false);

        Time.timeScale = 1f;
        IsGamePaused = false;
    }

    void Pause()
    {
        //mainMenuUI.SetActive(true);

        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitLevel()
    {
        //Debug.Log("Application quit");
        //Application.Quit();
        SceneManager.LoadScene("MainMenu");
    }
        
}
