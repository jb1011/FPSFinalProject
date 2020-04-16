using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class FlameThrower : MonoBehaviour
{
    [SerializeField]
    private IntVariable _playerHeatlth;

    [SerializeField]
    private Animator _UIAnim;

    private void OnTriggerStay(Collider other)
    {
        _playerHeatlth.Value--;
        CameraShaker.Instance.ShakeOnce(2f, 2f, 0.1f, 1f);
        _UIAnim.SetTrigger("PlayerHurt");
    }
}
