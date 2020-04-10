using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    private Transform _checkPoint;

    [SerializeField]
    GameObject _player;

    [SerializeField]
    private TextMeshProUGUI _deathMessage;

    [SerializeField]
    private Animator UIController;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            
            StartCoroutine(ReSpawn());
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.transform.CompareTag("Player"))
    //    {
    //        StartCoroutine(ReSpawn());
    //    }
    //}

    IEnumerator ReSpawn()
    {
        UIController.SetTrigger("Death");
        _deathMessage.enabled = true;
        
        yield return new WaitForSeconds(2f);
        _deathMessage.enabled = false;
        _player.transform.position = _checkPoint.position;
        _player.transform.rotation = _checkPoint.rotation;
    }
}
