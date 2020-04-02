using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private float range = 50f;

    [SerializeField]
    private ParticleSystem _shootParticle;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ShootRocket();
        }
    }
    private void ShootRocket()
    {
        _shootParticle.Play();
        RaycastHit hit;
        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}
