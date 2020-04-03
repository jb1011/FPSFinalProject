using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject _GuninHand;

    [SerializeField]
    private BoolVariable _hasHisGun;

    private void Start()
    {
        gameObject.SetActive(true);
        _GuninHand.SetActive(false);
        _hasHisGun.Value = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        gameObject.SetActive(false);
        _GuninHand.SetActive(true);
        _hasHisGun.Value = true;
        
    }
}
