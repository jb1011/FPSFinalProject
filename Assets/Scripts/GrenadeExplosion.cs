using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    [SerializeField]
    private float _blastRadius;

    [SerializeField]
    private float _explosionForce;

    private Collider[] hitColliders;

    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private LayerMask layerMask;

    private bool _hasExploded;

    private void Start()
    {
        _hasExploded = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!_hasExploded)
        {
            DoExplosion(collision.contacts[0].point);
            Instantiate(_explosion, collision.transform);
            Destroy(gameObject);
            _hasExploded = true;
        }
        
    }
    
    void DoExplosion(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, _blastRadius, layerMask);

        foreach(Collider hitcol in hitColliders)
        {
            if(hitcol.GetComponent<Rigidbody>() != null)
            {
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, explosionPoint, _blastRadius, 1, ForceMode.Impulse);
            }

        }
    }
}
