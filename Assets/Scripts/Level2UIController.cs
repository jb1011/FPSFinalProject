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
    // Start is called before the first frame update
    void Start()
    {
        _getInCar.enabled = true;
        _radio.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isIncar.Value)
        {
            _getInCar.enabled = false;
            _radio.enabled = true;
        }
        else
        {
            _radio.enabled = false;
        }
    }
}
