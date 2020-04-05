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

    [SerializeField]
    private float _impactForce = 50f;

    private float range = 50f;

    private float _nextTimeToFire = 0f;

    [SerializeField]
    private float _fireRate = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        _shootParticle.Play();
        _gunShot.Play();

        RaycastHit hit;
        if (Physics.Raycast(_gunPoint.position, _gunPoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.rigidbody != null)
            {
                Debug.Log("hey");
                hit.rigidbody.AddForce(-hit.normal * _impactForce);

            }
            Instantiate(m_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
