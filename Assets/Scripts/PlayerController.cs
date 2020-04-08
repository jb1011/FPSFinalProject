﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private Vector3 _inputs;
    private bool _isGrounded = true;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private float _originalSpeed;

    [SerializeField]
    private Transform groundCheckTransform;

    [SerializeField]
    private LayerMask groundCheckLayerMask;

    [SerializeField]
    private float _sprint;

    [SerializeField]
    private float _currentSpeed;

    [SerializeField]
    private BoolVariable IsInCar;

    [SerializeField]
    private AudioSource _jumpSound;

    [SerializeField]
    private AudioSource _itemSound;

    [SerializeField]
    private IntVariable _playerHealth;

    [SerializeField]
    private int _bulletDamage = 10;

    void Start()
    {
        _playerHealth.Value = 200;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!IsInCar.Value)
        {
            _inputs = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _currentSpeed = _sprint;
            }
            else
            {
                _currentSpeed = _originalSpeed;
            }

            if (Input.GetKey(KeyCode.Space) && _isGrounded)
            {
                _jumpSound.Play();
                _rb.AddForce(_jumpForce * transform.up, ForceMode.Impulse);
                _isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!IsInCar.Value)
        {
            _isGrounded = Physics.CheckSphere(groundCheckTransform.position, 0.3f, groundCheckLayerMask);
            Vector3 movement = _inputs.z * transform.forward + _inputs.x * transform.right;
            _rb.MovePosition(_rb.position + movement.normalized * _currentSpeed * Time.fixedDeltaTime);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            _itemSound.Play();
        }

        if (other.CompareTag("Bullet"))
        {
            _playerHealth.Value -= _bulletDamage;
        }

    }

}
