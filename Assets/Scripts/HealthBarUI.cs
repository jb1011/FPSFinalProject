using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private IntVariable _healthPlayer;

    [SerializeField]
    private IntVariable _maxHealth;

    [SerializeField]
    private Slider _bar;
    void Start()
    {
        _maxHealth.Value = 200;
        _healthPlayer.Value = _maxHealth.Value;
    }

    void Update()
    {
        _bar.value = (float)_healthPlayer.Value / (float)_maxHealth.Value;
    }
}
