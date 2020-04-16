using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocket : MonoBehaviour
{
    [SerializeField]
    private GameObject _grenade;

    [SerializeField]
    private Transform _spawnRocket;

    [SerializeField]
    private float _rocketSpeed;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnGrenade();
        }
    }

    void SpawnGrenade()
    {
        GameObject instBullet = Instantiate(_grenade, _spawnRocket.position, _spawnRocket.rotation) as GameObject;
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidbody.velocity = transform.rotation * Vector3.forward * _rocketSpeed;
    }
}
