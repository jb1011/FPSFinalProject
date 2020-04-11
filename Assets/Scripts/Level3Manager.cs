using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killCount;

    [SerializeField]
    private GameObject _collider;

    private void Start()
    {
        _collider.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(_killCount.Value == 12)
        {
            _collider.SetActive(false);
        }
    }
}
