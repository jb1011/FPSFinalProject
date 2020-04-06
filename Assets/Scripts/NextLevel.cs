using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private BoolVariable _hasHisGun;

    [SerializeField]
    private TextMeshProUGUI _needYourGun;

    [SerializeField]
    private Transform _player;

    private void Start()
    {
        _needYourGun.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _hasHisGun.Value)
        {
            SceneManager.LoadScene("Scene02");
        }
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !_hasHisGun.Value)
        {
            _needYourGun.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _needYourGun.enabled = false;
    }

    // just in case character go through a wall
    private void Update()
    {
        if(_player.position.y <= -20f)
        {
            SceneManager.LoadScene("Scene01");
        }
    }

}


