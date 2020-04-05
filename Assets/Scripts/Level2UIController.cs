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
    // Start is called before the first frame update
    void Start()
    {
        _getInCar.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isIncar.Value)
        {
            _getInCar.enabled = false;
        }
    }
}
