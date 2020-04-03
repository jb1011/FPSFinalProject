using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class DetectionParent : MonoBehaviour
{
    private Animator _anim;

    public BoolVariable CanPatrol;

    [SerializeField]
    private Transform _target;

    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private float closeDistance;

    [SerializeField]
    private AudioSource _angrySound;

    //[SerializeField]
    //private AudioSource _manHumming;

    public BoolVariable _hasHisGun;

    //[SerializeField]
    //private Animator _animUI;

    //[SerializeField]
    //private AudioSource _AudioUI;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        //_angrySound.volume = 0;
        //_animUI.SetBool("IsOver", false);
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
            //_anim.SetBool("IsYelling", false);
            _navMeshAgent.isStopped = false;

            Vector3 offset = _target.transform.position - transform.position;
            float sqrLen = offset.sqrMagnitude;
            //_manHumming.volume = 1;
            _angrySound.volume = 0;

            if (sqrLen <= closeDistance * closeDistance)
            {
                
                StartCoroutine("GotCaught");

            }
        }
    }

    IEnumerator GotCaught()
    {
        
        //_manHumming.volume = 0;
        _navMeshAgent.isStopped = true;
        _angrySound.Play();
        //_anim.SetBool("IsYelling", true);
        _anim.SetBool("IsIdle", false);
        _anim.SetBool("IsWalking", false);
       // _animUI.SetBool("IsOver", true);
        //_AudioUI.Play();
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerExit(Collider other)
    {
        CanPatrol.Value = true;

    }
}
