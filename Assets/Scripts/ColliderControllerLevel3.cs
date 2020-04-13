using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ColliderControllerLevel3 : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _cantGo;

    private void Start()
    {
        _cantGo.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cantGo.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _cantGo.enabled = false;
        }
    }
}
