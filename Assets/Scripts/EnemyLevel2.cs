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

    [SerializeField]
    private IntVariable _KillScore;

    private void Start()
    {
        _isdead = false;
        _hp = _enemyHealth;
        _KillScore.Value = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("MyCar") && !_isdead)
        {
            _isdead = true;
            _source.Play();
            _score.Value += 25;
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            _KillScore.Value++;
        }
    }

    public void Damage(int damage)
    {
        _hp -= damage;

        if(_hp <= 0)
        {
            _KillScore.Value++;
            _score.Value += 25;
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
