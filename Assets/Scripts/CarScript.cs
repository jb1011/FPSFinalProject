using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCamera;

    [SerializeField]
    private GameObject _carCamera;

    [SerializeField]
    private GameObject _player;

    public Rigidbody _rb;

    private Vector3 _input;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private Transform _playerRoom;

    [SerializeField]
    private Image _aim;

    public BoolVariable _isInCar;

    private AudioSource _carAcceleration;
    private void Start()
    {
        _carCamera.SetActive(false);
        _rb = GetComponent<Rigidbody>();
        _isInCar.Value = false;
        _carAcceleration = GetComponent<AudioSource>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            if (Input.GetKey(KeyCode.E))
            {

                _carCamera.SetActive(true);
                _mainCamera.SetActive(false);
                //_player.SetActive(false);
                _isInCar.Value = true;
                

            }
            
        }

    }

    private void Update()
    {
        if (_isInCar.Value)
        {
            _input = new Vector3(0, 0, Input.GetAxis("Vertical"));
            Vector3 movement = _input.z * transform.forward;
            _rb.MovePosition(_rb.position + movement.normalized * _speed * Time.deltaTime);
            _player.transform.position = _playerRoom.position;

            _aim.enabled = false;

            if(Input.GetAxis("Vertical") > 0f)
            {
                _carAcceleration.volume = 1f;
            }
        }
        else
        {
            _aim.enabled = true;
            _carAcceleration.volume = 0f;
        }
        if (Input.GetKey(KeyCode.Space) && _isInCar)
        {
            _isInCar.Value = false;
            _carCamera.SetActive(false);
            _mainCamera.SetActive(true);
            _player.SetActive(true);
        }
    }
}
