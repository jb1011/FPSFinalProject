using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _characterRb;

    [SerializeField]
    private float _lookSpeed = 10f;

    private float _camRotation;

    [SerializeField]
    private GameObject _runEffect;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
        float y = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Mouse X");

        _camRotation -= y * _lookSpeed * Time.deltaTime;
        _camRotation = Mathf.Clamp(_camRotation, -30f, 40f);

        transform.localRotation = Quaternion.Euler(_camRotation, 0, 0);

        _characterRb.rotation = Quaternion.Euler(_characterRb.rotation.eulerAngles + x * _lookSpeed * Time.deltaTime * Vector3.up);

        if(x > 0.3 || y > 0.3 || x < -0.3 || y < -0.3)
        {
            _runEffect.SetActive(false);
        }
    }
}
