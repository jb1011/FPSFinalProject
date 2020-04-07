using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeExplosion : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    public IntVariable _score;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Car")) 
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            _score.Value += 10;
        }
    }
    private IEnumerator Death()
    {
        Instantiate(_explosion, transform.position, transform.rotation);
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
