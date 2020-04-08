using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLevel2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private AudioSource _source;

    public IntVariable _score;

    private bool _isdead;

    private int _hp;

    [SerializeField]
    private int _enemyHealth = 100;

    [SerializeField]
    private Slider _bar;

    private void Start()
    {
        _isdead = false;
        _hp = _enemyHealth;
        _bar.value = 1f;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Car") && !_isdead)
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

    private void Update()
    {
        _bar.value = (float)_hp / (float)_enemyHealth;
    }
}
