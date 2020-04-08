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

    [SerializeField]
    private GameObject _bullet;

    private float _bulletSpeed = 10f;

    [SerializeField]
    private Transform _spawn;


    private float _timer = 2f;
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
                StartCoroutine(Fire());
                _anim.SetBool("IsShooting", true);
                
                _timer = 2f;
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

    IEnumerator Fire()
    {
        yield return new WaitForSeconds(0.4f);
        GameObject instBullet = Instantiate(_bullet, _spawn.position, _spawn.rotation) as GameObject;
        Rigidbody instBulletRigidbody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidbody.velocity = transform.rotation * Vector3.forward * _bulletSpeed;
    }

}
