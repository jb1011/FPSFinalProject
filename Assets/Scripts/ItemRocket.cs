using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject _GuninHand;
    private void Start()
    {
        gameObject.SetActive(true);
        _GuninHand.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        gameObject.SetActive(false);
        _GuninHand.SetActive(true);
    }
}
