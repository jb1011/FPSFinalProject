using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Transform _checkPoint;

    [SerializeField]
    GameObject _player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(ReSpawn());
        }
    }

    IEnumerator ReSpawn()
    {
        

        yield return new WaitForSeconds(2f);
        _player.transform.position = _checkPoint.position;
        _player.transform.rotation = _checkPoint.rotation;
    }
}
