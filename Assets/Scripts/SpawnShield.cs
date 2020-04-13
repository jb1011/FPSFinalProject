using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShield : MonoBehaviour
{
    [SerializeField]
    private GameObject _shield;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject)
        {
            Debug.Log("hey");
            Instantiate(_shield);
        }
    }
}
