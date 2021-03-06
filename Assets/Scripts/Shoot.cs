﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float range = 50f;

    [SerializeField]
    private ParticleSystem _shootParticle;

    public GameObject m_impactEffect;

    public GameObject m_bloodEffect;

    [SerializeField]
    private Image _aimImage;

    [SerializeField]
    private float _fireRate = 15f;

    [SerializeField]
    private Transform _gunPoint;

    private float _nextTimeToFire = 0f;

    [SerializeField]
    private AudioSource _gunShot;

    [SerializeField]
    LayerMask _layerEnemy;

    [SerializeField]
    LayerMask _allLayers;

    [SerializeField]
    LayerMask _parentLayer;

    [SerializeField]
    private TextMeshProUGUI _textParent;

    private int damage = 10;

    private void Start()
    {
        _textParent.enabled = false;
    }
    private void Update()
    {
        RaycastHit hitInfo;

        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hitInfo, range, _layerEnemy, QueryTriggerInteraction.Ignore))
        {
            _aimImage.color = new Color(255f, 0, 0);
            _aimImage.CrossFadeAlpha(0.7f, 0.5f, false);
            
        }
        else
        {
            //green
            _aimImage.color = new Color(0, 255f, 0, 120f);
            _aimImage.CrossFadeAlpha(0.4f, 0.5f, false);
        }

        if (Input.GetButton("Fire1") && Time.time >= _nextTimeToFire)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;
            ShootRocket();

            RaycastHit _hit;
            if (Physics.Raycast(_gunPoint.position, _camera.transform.forward, out _hit, range, _parentLayer, QueryTriggerInteraction.Ignore))
            {
                StartCoroutine(ShowMessage());
                
            }
        }
    }
    
    private void ShootRocket()
    {
        _shootParticle.Play();
        _gunShot.Play();
        RaycastHit hit;
        if(Physics.Raycast(_gunPoint.position, _camera.transform.forward, out hit, range, _layerEnemy, QueryTriggerInteraction.Ignore))
        {
            EnemyLevel2 _enemy = hit.transform.GetComponent<EnemyLevel2>();

            if(_enemy != null)
            {
                _enemy.Damage(damage);
                Instantiate(m_bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
            }    
        }

        if (Physics.Raycast(_gunPoint.position, _camera.transform.forward, out hit, range, _allLayers, QueryTriggerInteraction.Ignore))
        {
            Instantiate(m_impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
        }

    }

    IEnumerator ShowMessage()
    {
        _textParent.enabled = true;
        yield return new WaitForSeconds(2f);
        _textParent.enabled = false;
    }
}
