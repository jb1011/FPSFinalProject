using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private float range = 50f;

    [SerializeField]
    private ParticleSystem _shootParticle;

    [SerializeField]
    private float _impactForce = 50f;

    public GameObject m_impactEffect;

    [SerializeField]
    private Image _aimImage;

    [SerializeField]
    private float _fireRate = 15f;

    [SerializeField]
    private Transform _gunPoint;

    private float _nextTimeToFire = 0f;

    [SerializeField]
    private AudioSource _gunShot;

    private void Update()
    {
        RaycastHit hitInfo;

        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hitInfo, range))
        {
            _aimImage.color = new Color(0f, 255f, 0, 120f);
            _aimImage.CrossFadeAlpha(0.7f, 0.5f, false);

            if (hitInfo.rigidbody != null)
            {
                _aimImage.color = new Color(255f, 0, 0);
                _aimImage.CrossFadeAlpha(0.7f, 0.5f, false);
            }
            
        }
        else
        {
            _aimImage.color = new Color(255f, 255f, 255f, 120f);
            _aimImage.CrossFadeAlpha(0.4f, 0.5f, false);
        }

        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            ShootRocket();
        }
    }
    private void ShootRocket()
    {
        _shootParticle.Play();
        _gunShot.Play();
        RaycastHit hit;
        if(Physics.Raycast(_gunPoint.position, _camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if(hit.rigidbody != null)
            {
                Debug.Log("hey");
                hit.rigidbody.AddForce(-hit.normal * _impactForce);
                
            }
            Instantiate(m_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
    }
}
