using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExplosion : MonoBehaviour
{
    [SerializeField]
    GameObject _explosion;

    [SerializeField]
    Transform _spawnExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(_explosion, _spawnExplosion);
        }
    }
}
