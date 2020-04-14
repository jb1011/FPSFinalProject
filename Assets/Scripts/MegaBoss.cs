using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MegaBoss : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private Transform _target;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _navMeshAgent.isStopped = false;
            _navMeshAgent.destination = _target.transform.position;
        }
    }
}
