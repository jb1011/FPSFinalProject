using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEnterLevel3 : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killCount;

    [SerializeField]
    private TextMeshProUGUI _textNotPossible;

    [SerializeField]
    private TextMeshProUGUI _textGo;

    private void Start()
    {
        _textNotPossible.enabled = false;
        _textGo.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && _killCount.Value < 15)
        {
            _textNotPossible.enabled = true;
        }

        if (other.CompareTag("Player") && _killCount.Value >= 15)
        {
            _textGo.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _textNotPossible.enabled = false;
        _textGo.enabled = false;
    }
}
