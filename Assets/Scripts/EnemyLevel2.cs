﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private AudioSource _source;

    public IntVariable _score;

    private bool _isdead;

    [SerializeField]
    private int _hp;

    private void Start()
    {
        _isdead = false;
        _hp = 100;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") && !_isdead)
        {
            _isdead = true;
            _source.Play();
            _score.Value += 50;
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void Damage(int damage)
    {
        _hp -= damage;

        if(_hp <= 0)
        {
            _score.Value += 50;
            _isdead = true;
            _source.Play();
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
