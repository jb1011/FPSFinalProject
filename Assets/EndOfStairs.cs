using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfStairs : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _canGoUpStairs;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _canGoUpStairs.enabled = false;
        }
    }

}
