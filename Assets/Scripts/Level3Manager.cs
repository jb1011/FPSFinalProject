using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Manager : MonoBehaviour
{
    [SerializeField]
    private IntVariable _killCount;

    [SerializeField]
    private GameObject _collider;

    [SerializeField]
    private AudioSource _levelUp;

    private bool _hasPlayed;

    [SerializeField]
    private GameObject _boss;
    private void Start()
    {
        _hasPlayed = false;
        _collider.SetActive(true);
        _boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_killCount.Value == 12 && !_hasPlayed)
        {
            _levelUp.Play();
            _collider.SetActive(false);
            _hasPlayed = true;
        }

        if(_killCount.Value == 20)
        {

            _boss.SetActive(true);
        }
    }
}
