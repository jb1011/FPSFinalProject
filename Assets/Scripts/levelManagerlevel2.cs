using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManagerlevel2 : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    // Update is called once per frame
    void Update()
    {
        if(_player.position.y <= -25f)
        {
            SceneManager.LoadScene("Scene02");
        }   
    }
}
