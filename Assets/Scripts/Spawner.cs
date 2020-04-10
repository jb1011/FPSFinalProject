using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField]
    //private GameObject _alien;

    //private int _xPos;
    //private int _zPos;

    //private int _enemyCount;

    [SerializeField]
    private GameObject[] _cars;

    private bool _spawned = false;

    private void Start()
    {
        foreach(GameObject _car in _cars)
        {
            _car.SetActive(false);
        }


        //_cars.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && !_spawned)
        {
            _spawned = true;
            //while(_enemyCount < 20)
            //{
            //    _xPos = Random.Range(-96, -190);
            //    _zPos = Random.Range(-263, -194);
            //    Instantiate(_alien, new Vector3(_xPos, 18.5f, _zPos), Quaternion.identity);
            //    _enemyCount++;
            //}

            //_car.SetActive(true);
            foreach (GameObject _car in _cars)
            {
                _car.SetActive(true);
            }
        }
    }
}
