using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using TMPro;

public class DetectionParent : MonoBehaviour
{
    private Animator _anim;

    public BoolVariable CanPatrol;

    [SerializeField]
    private Transform _target;

    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private float closeDistance;

    public BoolVariable _hasHisGun;

    [SerializeField]
    private TextMeshProUGUI _gotCaught;

    private AudioSource _getCaughtSound;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _gotCaught.enabled = false;
        _getCaughtSound = GetComponent<AudioSource>();
        _getCaughtSound.volume = 0;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && _hasHisGun.Value)
        {
            _navMeshAgent.isStopped = false;

            CanPatrol.Value = false;

            _navMeshAgent.destination = _target.transform.position;

            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsWalking", true);
            _navMeshAgent.isStopped = false;

            Vector3 offset = _target.transform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;


            if (sqrLen < closeDistance * closeDistance)
            {
                _getCaughtSound.volume = 1f;
                StartCoroutine("GotCaught");

            }
        }
    }

    IEnumerator GotCaught()
    {
        _navMeshAgent.isStopped = true;

        _anim.SetBool("IsIdle", true);
        _anim.SetBool("IsWalking", false);
        _gotCaught.enabled = true;
        
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerExit(Collider other)
    {
        CanPatrol.Value = true;

    }
}
