using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarExplosion : MonoBehaviour
{
    [SerializeField]
    GameObject _explosion;

    [SerializeField]
    Transform _spawnExplosion;

    [SerializeField]
    AudioSource _explosionNoise;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _explosionNoise.Play();
            Instantiate(_explosion, _spawnExplosion);
        }
    }
}
