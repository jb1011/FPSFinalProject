using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCamera : MonoBehaviour
{

    [SerializeField]
    private Rigidbody _carRb;

    [SerializeField]
    private float _lookSpeed = 10f;

    private float _camRotation;

    [SerializeField]
    private BoolVariable IsInCar;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Mouse X");

        _camRotation -= y * _lookSpeed * Time.deltaTime;
        _camRotation = Mathf.Clamp(_camRotation, -25f, 20f);

        transform.localRotation = Quaternion.Euler(_camRotation, 0, 0);

        if (IsInCar.Value)
        {
            _carRb.rotation = Quaternion.Euler(_carRb.rotation.eulerAngles + x * _lookSpeed * Time.deltaTime * Vector3.up);
        }

    }
}
