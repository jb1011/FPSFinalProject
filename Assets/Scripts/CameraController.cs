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
        _characterRb.rotation = Quaternion.Euler(_characterRb.rotation.eulerAngles + x * _lookSpeed * Time.deltaTime * Vector3.up);

        if (Input.GetMouseButton(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
