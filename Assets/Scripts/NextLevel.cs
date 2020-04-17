using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private BoolVariable _hasHisGun;

    [SerializeField]
    private TextMeshProUGUI _needYourGun;

    [SerializeField]
    private Transform _player;

    [SerializeField]
    private GameObject _loadingScreen;

    [SerializeField]
    private Slider _slider;

    private void Start()
    {
        _needYourGun.enabled = false;
        _loadingScreen.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _hasHisGun.Value)
        {
            StartCoroutine(LoadAsynchronously(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_hasHisGun.Value)
        {
            _needYourGun.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _needYourGun.enabled = false;
    }


    public void LevelLoader(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        _loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);
            _slider.value = progress;

            yield return null;
        }
    }
}


