﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRunShoot : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _rotationSpeed = 1f;

    private Animator _anim;

    [SerializeField]
    private bool _playerInSight;

    [SerializeField]
    private GameObject _bullet;

    [SerializeField]
    private float _bulletSpeed = 50f;

    [SerializeField]
    private Transform _spawn;

    [SerializeField]
    private AudioSource _gunSound;

    private NavMeshAgent _navMeshAgent;

    private float _timer = 2f;

    private float _secondTimer = 1f;

    private bool _hasShot = false;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_player)
        {
            //for the enemy rotation
            Vector3 targetDirection = _player.position - transform.position;
            float singleStep = _rotationSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        if (_playerInSight)
        {
            //for the shooting
            if (_timer > 0)
            {
                _timer -= Time.deltaTime;
                _anim.SetBool("IsShooting", false);
                _navMeshAgent.isStopped = false;
                _anim.SetBool("IsRunning", true);
                _navMeshAgent.destination = _player.transform.position;
                _secondTimer = 1f;
            }
            else
            {
                _navMeshAgent.destination = gameObject.transform.position;
                _navMeshAgent.isStopped = true;
                _anim.SetBool("IsRunning", false);   
                _anim.SetBool("IsShooting", true);
                
                _secondTimer -= Time.deltaTime;

                if (!_hasShot) 
                {
                    ShootBullet();
                    _hasShot = true;
                }
                
                if (_secondTimer <= 0)
                {
                    _hasShot = false;
                    _timer = 1f;
                }
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _playerInSight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            _playerInSight = false;
        }
    }

    //IEnumerator Fire()
    //{
    //    yield return new WaitForSeconds(0.4f);
    //    GameObject instBullet = Instantiate(_bullet, _spawn.position, _spawn.rotation) as GameObject;
    //    Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
    //    instBulletRigidbody.velocity = transform.rotation * Vector3.forward * _bulletSpeed;
    //}

    public void ShootBullet()
    {
        _gunSound.Play();
        GameObject instBullet = Instantiate(_bullet, _spawn.position, _spawn.rotation) as GameObject;
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidbody.velocity = transform.rotation * Vector3.forward * _bulletSpeed;
        
    }

}
