using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _timer = 3f;

    // Update is called once per frame
    void Update()
    {
        if(_timer >= 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
