using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2ndFloor : MonoBehaviour
{
    [SerializeField]
    GameObject _explosion;

    [SerializeField]
    Transform _spawn;

    [SerializeField]
    AudioSource _explosionNoise;

    private bool _hasExploded = false;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Ground") && !_hasExploded)
        {
            _hasExploded = true;
            Instantiate(_explosion, _spawn);
            _explosionNoise.Play();
        }
    }
}
