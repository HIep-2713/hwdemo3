using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class ZombieMovement : MonoBehaviour
{
    public Transform playerfoot;
    public Animator ani;
    public NavMeshAgent agent;
    public float reachingRadius;
    public UnityEvent onDestinationReached;
    public UnityEvent onStartMoving;

    private bool _isMovingValue;
    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if(_isMovingValue==value) return;
            _isMovingValue = value;
            OnIsMovingvalueChange();
        }
    }

    private void OnIsMovingvalueChange()
    {
        agent.isStopped = !_isMovingValue;
        ani.SetBool("IsWalking", _isMovingValue);
        if(_isMovingValue )
        {
            onStartMoving.Invoke();
        }
        else
        {
            onDestinationReached.Invoke();
        }
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, playerfoot.position);
        IsMoving = distance > reachingRadius; 
        if(IsMoving )
        {
            agent.SetDestination(playerfoot.position);
        }
    }

}
