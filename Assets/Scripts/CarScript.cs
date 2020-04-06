using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private AudioSource _carMusic;

    private Animator _anim;

    [SerializeField]
    private GameObject _gunCar;

    [SerializeField]
    private TextMeshProUGUI _timeToPurgeText;

    private float timer = 3f;

    [SerializeField]
    private AudioSource _letsgo;

    [SerializeField]
    private AudioSource _sirene;


    private void Start()
    {
        _carCamera.SetActive(false);
        _gunCar.SetActive(false);
        _rb = GetComponent<Rigidbody>();
        _isInCar.Value = false;
        _carMusic = GetComponent<AudioSource>();
        _anim = GetComponent<Animator>();
        _timeToPurgeText.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            if (Input.GetKey(KeyCode.E))
            {

                _carCamera.SetActive(true);
                _gunCar.SetActive(true);
                _mainCamera.SetActive(false);
                //_player.SetActive(false);
                _isInCar.Value = true;
                _letsgo.Play();
                _sirene.Play();

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

            //_rb.AddForce(_input.z * transform.forward * _speed, ForceMode.Acceleration);
            _player.transform.position = _playerRoom.position;

            _aim.enabled = false;
            _carMusic.volume = 1f;

            if (Input.GetButton("Fire1"))
            {
                _anim.SetBool("IsShooting", true);
            }
            else
            {
                _anim.SetBool("IsShooting", false);
            }

            if (timer > 0)
            {
                _timeToPurgeText.enabled = true;
                timer -= Time.deltaTime;
                return;
            }
            if(timer <= 0)
            {
                _timeToPurgeText.enabled = false;
            }

        }
        else
        {
            _aim.enabled = true;
            _carMusic.volume = 0f;
        }
        if (Input.GetKey(KeyCode.Space) && _isInCar)
        {
            _isInCar.Value = false;
            _carCamera.SetActive(false);
            _gunCar.SetActive(false);
            _mainCamera.SetActive(true);
            _player.SetActive(true);
        }
    }
}
