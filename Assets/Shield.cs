using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField]
    private IntVariable _healthPlayer;

    [SerializeField]
    private IntVariable _maxHealthPlayer;

    [SerializeField]
    private AudioSource _item;

    private void Awake()
    {
        _item = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player") && _healthPlayer.Value < _maxHealthPlayer.Value)
        {
            
            _healthPlayer.Value += 10;
            StartCoroutine(Collect());
            
        }
    }

    IEnumerator Collect()
    {
        _item.Play();
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
