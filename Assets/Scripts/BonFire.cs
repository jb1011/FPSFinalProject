using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonFire : MonoBehaviour
{

    [SerializeField]
    private IntVariable _playerHealth;

    [SerializeField]
    private AudioSource _hurtSound;

    [SerializeField]
    private Animator _UIController;
    private void OnTriggerStay(Collider other)
    {
        _playerHealth.Value--;
        _hurtSound.Play();
        _UIController.SetTrigger("PlayerHurt");
    }
}
