using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private float _rotationSpeed = 1f;

    private Animator _anim;

    [SerializeField]
    private bool _playerInSight;

    private float _timer = 1f;
    private void Start()
    {
        _anim = GetComponent<Animator>();
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
            if(_timer > 0)
            {
                _timer -= Time.deltaTime;
                _anim.SetBool("IsShooting", false);
            }
            else
            {
                _anim.SetBool("IsShooting", true);
                _timer = 1f;
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
}
