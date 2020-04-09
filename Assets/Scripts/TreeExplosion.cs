using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeExplosion : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    public IntVariable _score;

    private AudioSource _destruction;

    private void Start()
    {
        _destruction = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Car")) 
        {
            _destruction.Play();
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            _score.Value += 10;
            //StartCoroutine(Death());
        }
    }
    //private IEnumerator Death()
    //{
    //    _destruction.Play();
    //    _score.Value += 10;
    //    Instantiate(_explosion, transform.position, transform.rotation);
    //    yield return new WaitForSeconds(0.1f);
    //    Destroy(gameObject);
    //}
}
