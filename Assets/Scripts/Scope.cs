using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scope : MonoBehaviour
{
    private bool isScoped = false;

    [SerializeField]
    private Camera _mainCamera;

    [SerializeField]
    private float _scopedFOV = 15f;

    [SerializeField]
    private Image _aim;

    [SerializeField]
    private float _zoomAim;

    private float _normalFOV;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
             if (isScoped)
            {
                _normalFOV = _mainCamera.fieldOfView;
                _mainCamera.fieldOfView = _scopedFOV;
                _aim.transform.localScale *= _zoomAim;
            }
            else
            {
                _mainCamera.fieldOfView = _normalFOV;
                _aim.transform.localScale /= _zoomAim;
            }
        }        
    }
}
