using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField]
    private IntVariable _healthEnemy;

    [SerializeField]
    private IntVariable _maxHealth;

    [SerializeField]
    private Slider _bar;
    void Start()
    {
        _maxHealth.Value = 200;
        _healthEnemy.Value = _maxHealth.Value;
    }

    void Update()
    {
        
        //_bar.value = (float)_healthEnemy.Value / (float)_maxHealth.Value;
    }
}
