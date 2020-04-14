using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level2UIController : MonoBehaviour
{
    [SerializeField]
    private BoolVariable _isIncar;

    [SerializeField]
    private TextMeshProUGUI _getInCar;

    [SerializeField]
    private TextMeshProUGUI _radio;

    [SerializeField]
    private IntVariable _killCount;

    [SerializeField]
    private TextMeshProUGUI _waterfall;

    private float timer = 5f;

    private float _otherTimer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _killCount.Value = 0;
        _getInCar.enabled = true;
        _radio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            _getInCar.enabled = false;
        }

        if (_isIncar.Value)
        {
            _getInCar.enabled = false;
            _radio.enabled = true;
        }
        else
        {
            _radio.enabled = false;
        }

        if(_killCount.Value == 15)
        {
            if(_otherTimer > 0)
            {
                _waterfall.enabled = true;
                _otherTimer -= Time.deltaTime;
            }
            else
            {
                _waterfall.enabled = false;

            }
        }
    }
}
