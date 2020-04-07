﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCar : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem _shootParticle;

    [SerializeField]
    private AudioSource _gunShot;

    [SerializeField]
    private Transform _gunPoint;

    public GameObject m_impactEffect;

    [SerializeField]
    private float _impactForce = 50f;

    private float range = 50f;

    private float _nextTimeToFire = 0f;

    [SerializeField]
    private float _fireRate = 15f;

    private AudioSource _scream;

    [SerializeField]
    private LayerMask _layerEnemy;

    private int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        _scream = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            Shoot();
        }

    }

    private void Shoot()
    {
        //_shootParticle.Play();
        //_gunShot.Play();
        //_scream.Play();

        //RaycastHit hit;
        //if (Physics.Raycast(_gunPoint.position, _gunPoint.transform.forward, out hit, range))
        //{
        //    Debug.Log(hit.transform.name);

        //    if (hit.rigidbody != null)
        //    {
        //        Debug.Log("hey");
        //        hit.rigidbody.AddForce(-hit.normal * _impactForce);
        //        m_EnemyHealth.Value -= 10;

        //    }
        //    Instantiate(m_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //}

        _shootParticle.Play();
        _gunShot.Play();
        _scream.Play();
        RaycastHit hit;
        if (Physics.Raycast(_gunPoint.position, _gunPoint.transform.forward, out hit, range, _layerEnemy))
        {
            EnemyLevel2 _enemy = hit.transform.GetComponent<EnemyLevel2>();

            if (_enemy != null)
            {
                _enemy.Damage(damage);
            }

        }

        if (Physics.Raycast(_gunPoint.position, _gunPoint.transform.forward, out hit, range))
        {
            Instantiate(m_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
