using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCanvas;

    [SerializeField]
    private GameObject _secondCanvas;

    [SerializeField]
    private AudioSource _button;

    private void Start()
    {
        _mainCanvas.SetActive(true);
        _secondCanvas.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void Play()
    {
        SceneManager.LoadScene("Scene00");
        _button.Play();
    }

    public void Settings()
    {
        _mainCanvas.SetActive(false);
        _secondCanvas.SetActive(true);
        _button.Play();
    }

    public void Return()
    {
        _mainCanvas.SetActive(true);
        _secondCanvas.SetActive(false);
        _button.Play();
    }
}
