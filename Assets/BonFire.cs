using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonFire : MonoBehaviour
{

    [SerializeField]
    private IntVariable _playerHealth;
    private void OnTriggerStay(Collider other)
    {
        _playerHealth.Value--;

    }
}
