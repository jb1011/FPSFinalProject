using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]
    private BoolVariable _hasHisGun;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && _hasHisGun.Value)
        {
            SceneManager.LoadScene("Scene02");
        }
    }
}
