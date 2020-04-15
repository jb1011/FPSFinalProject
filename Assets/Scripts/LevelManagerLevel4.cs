using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerLevel4 : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killScore;

    [SerializeField]
    private GameObject _miniBoss;

    [SerializeField]
    private GameObject _spawnEffectMiniBoss;

    private float _timer;
    void Start()
    {
        _killScore.Value = 0;
        _miniBoss.SetActive(false);
        _spawnEffectMiniBoss.SetActive(false);
        _timer = 3f;
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
    }
}
