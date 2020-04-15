using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerLevel4 : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killScore;

    [SerializeField]
    private GameObject _miniBoss;

    [SerializeField]
    private GameObject _spawnEffectMiniBoss;

    [SerializeField]
    private GameObject _thirdWave;

    [SerializeField]
    private GameObject _spawnEffectThirdWave;

    [SerializeField]
    private GameObject _congrats;

    private float _timer;
    private float _secondTimer;
    private float _thirdTimer;
    void Start()
    {
        _killScore.Value = 0;
        _miniBoss.SetActive(false);
        _spawnEffectMiniBoss.SetActive(false);
        _thirdWave.SetActive(false);
        _spawnEffectThirdWave.SetActive(false);
        _timer = 3f;
        _secondTimer = 3f;
        _thirdTimer = 5f;
        _congrats.SetActive(false);
    }

    void Update()
    {
        if(_killScore.Value == 1 && _timer > 0)
        {
            _spawnEffectMiniBoss.SetActive(true);
            _timer -= Time.deltaTime;
        }
        if(_timer <= 0)
        {
            _miniBoss.SetActive(true);
        }

        if(_killScore.Value == 4 && _secondTimer > 0)
        {
            _spawnEffectThirdWave.SetActive(true);
            _secondTimer -= Time.deltaTime;
        }
        if(_secondTimer <= 0)
        {
            _thirdWave.SetActive(true);
        }
        if(_killScore.Value == 6 && _thirdTimer > 0)
        {
            _congrats.SetActive(true);
            _thirdTimer -= Time.deltaTime;
        }
        if(_thirdTimer <= 0)
        {
            SceneManager.LoadScene("Scene05");
        }
    }
}
