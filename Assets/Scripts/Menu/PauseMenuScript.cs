using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject gunHolder;

    private static bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Player != null)
        {

            if (isPaused)
            {
                Resume();
            }
            else
            {
                PauseOn();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        gunHolder.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseOn()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        gunHolder.SetActive(false);
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu");
        Player.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
