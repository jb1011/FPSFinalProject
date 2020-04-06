using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolSimple : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform[] patrolPoints;
    private int currentControlPointIndex = 0;

    private Animator _anim;

    void Awake()
    {
        _anim = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        MoveToNextPatrolPoint();

    }



    void Update()
    {

        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.1f)
        {

            MoveToNextPatrolPoint();
        }

    }

    float timer = 1f;
    private void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            if (timer > 0)
            {
                _anim.SetBool("IsIdle", true);
                _anim.SetBool("IsWalking", false);
                timer -= Time.deltaTime;
                return;
            }
            _anim.SetBool("IsIdle", false);
            _anim.SetBool("IsWalking", true);
            navMeshAgent.destination = patrolPoints[currentControlPointIndex].position;
            currentControlPointIndex++;
            currentControlPointIndex %= patrolPoints.Length;
            timer = 3f;
        }
    }
}
