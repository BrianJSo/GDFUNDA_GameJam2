using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    [SerializeField] public GameObject options;
    [SerializeField] public GameObject controller;
    [SerializeField] public GameObject fpsCam;
    [SerializeField] public GameObject pauseCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        //fpsCam.SetActive(true);
        //pauseCam.SetActive(false);
        controller.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        //fpsCam.SetActive(false);
        //pauseCam.SetActive(true);
        controller.GetComponent<FirstPersonController>().enabled = false;
        controller.GetComponent<FirstPersonController>().m_MouseLook.SetCursorLock(false);
        controller.GetComponent<FirstPersonController>().m_MouseLook.UpdateCursorLock();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadTitleScreen()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartMenu");
    }

    public void OptionsMenu()
    {
        pauseMenu.SetActive(false);
        options.SetActive(true);       
    }

    public void Quit()
    {
        Debug.Log("Application quits");
        Application.Quit();
    }
}
