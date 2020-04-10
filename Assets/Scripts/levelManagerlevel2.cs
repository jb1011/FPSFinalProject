﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManagerlevel2 : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private IntVariable _playerHealth;

    [SerializeField]
    private BoolVariable _isInCar;

    public bool GameIsPaused;

    public GameObject PauseMenuUI;


    private void Start()
    {
        _isInCar.Value = false;
        GameIsPaused = false;
        PauseMenuUI.SetActive(false);
    }

    void Update()
    {
        //if player go through walls
        if(_player.position.y <= -25f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        //if player wants to pause the game
        if (Input.GetKey(KeyCode.Escape) && !GameIsPaused)
        {
            Pause();
        }

        if (GameIsPaused && Input.GetKey(KeyCode.Space))
        {
            Resume();
        }

        //if player dies
        if(_playerHealth.Value <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
