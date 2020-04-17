using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

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
    private AudioSource _getsHitSound;

    [SerializeField]
    private IntVariable _playerHealth;

    [SerializeField]
    private int _bulletDamage = 10;

    [SerializeField]
    private Animator _UIController;

    [SerializeField]
    private GameObject _runEffect;

    private Vector3 inputVector;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!IsInCar.Value)
        {
            _inputs = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            

            if (Input.GetKey(KeyCode.LeftShift))
            {
                _currentSpeed = _sprint;
                
            }
            else
            {
                _currentSpeed = _originalSpeed;
                _runEffect.SetActive(false);
            }

            if(Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0)
            {
                _runEffect.SetActive(true);
            }

            if (Input.GetKey(KeyCode.Space) && _isGrounded)
            {
                _jumpSound.Play();
                _rb.AddForce(_jumpForce * transform.up, ForceMode.Impulse);
                _isGrounded = false;
            }
        }

        if (IsInCar.Value)
        {
            _runEffect.SetActive(false);
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
            _UIController.SetTrigger("PlayerHurt");
            _getsHitSound.Play();
            _playerHealth.Value -= _bulletDamage;
            CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        }

    }

}
