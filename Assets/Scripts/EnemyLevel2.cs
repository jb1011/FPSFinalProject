using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevel2 : MonoBehaviour
{
    [SerializeField]
    private GameObject _explosion;

    private Animator _anim;

    private AudioSource _source;

    public IntVariable m_enemyHP;

    public FloatVariable _score;

    private bool _isdead;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _source = GetComponent<AudioSource>();
        m_enemyHP.Value = 100;
        _isdead = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
            StartCoroutine(Death());

    }

    private void Update()
    {
        if(m_enemyHP.Value <= 0 && !_isdead)
        {
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        _isdead = true;
        _source.Play();
        _score.Value += 100f;
        Instantiate(_explosion, transform.position, transform.rotation);
        _anim.SetTrigger("IsDead");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
