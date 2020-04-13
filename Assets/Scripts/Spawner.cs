using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _cars;

    [SerializeField]
    private BoolVariable _spawned;

    [SerializeField]
    private GameObject _lava;

    [SerializeField]
    private TextMeshProUGUI _deathMessage;

    private void Start()
    {
        _spawned.Value = false;
        _lava.SetActive(false);
        _deathMessage.enabled = false;
        foreach (GameObject _car in _cars)
        {
            _car.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && !_spawned.Value)
        {
            _spawned.Value = true;
            

            foreach (GameObject _car in _cars)
            {
                _car.SetActive(true);
            }
            _lava.SetActive(true);
        }
    }
}
