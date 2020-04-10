using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _cars;

    private bool _spawned = false;

    private void Start()
    {
        foreach(GameObject _car in _cars)
        {
            _car.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && !_spawned)
        {
            _spawned = true;

            foreach (GameObject _car in _cars)
            {
                _car.SetActive(true);
            }
        }
    }
}
