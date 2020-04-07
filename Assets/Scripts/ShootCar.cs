using System.Collections;
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

    private float range = 50f;

    private float _nextTimeToFire = 0f;

    [SerializeField]
    private float _fireRate = 15f;

    private AudioSource _scream;

    [SerializeField]
    private LayerMask _layerEnemy;

    private int damage = 10;

    void Start()
    {
        _scream = GetComponent<AudioSource>();
    }

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
