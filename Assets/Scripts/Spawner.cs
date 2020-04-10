using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _cars;

    [SerializeField]
    private BoolVariable _spawned;

    private void Start()
    {
        _spawned.Value = false;
        foreach(GameObject _car in _cars)
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
        }
    }
}
