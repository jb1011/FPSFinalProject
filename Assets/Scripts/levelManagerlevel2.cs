using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManagerlevel2 : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    public bool GameIsPaused;

    public GameObject PauseMenuUI;

    //private void Start()
    //{
    //    PauseMenuUI.SetActive(false);    
    //}

    private void Start()
    {
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
    }

    void Update()
    {
        if(_player.position.y <= -25f)
        {
            SceneManager.LoadScene("Scene02");
        }

        if (Input.GetKey(KeyCode.Escape) && !GameIsPaused)
        {
            Pause();
        }

        if (GameIsPaused && Input.GetKey(KeyCode.Space))
        {
            Resume();
        }

    }

    void Pause()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }

    void Resume()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
