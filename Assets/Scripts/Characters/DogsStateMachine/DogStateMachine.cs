using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;



public class DogStateMachine : MonoBehaviour
{
    DogState m_currentState;

    protected Rigidbody m_Rigidbody;

    protected Animator m_Animator;

    protected SphereCollider m_Collider; 
    
    protected NavMeshAgent m_Agent;

    [SerializeField] DogData dogProperties;

    private void Start()
    {
        m_currentState = new PlayerControlled(this, dogProperties);

        m_Rigidbody = GetComponent<Rigidbody>();

        m_Animator = GetComponent<Animator>();

        m_Collider = GetComponent<SphereCollider>();  
        
        m_Agent = GetComponent<NavMeshAgent>();
    }

    public void SetState(DogState state)
    {
        m_currentState = state;
    }

    public virtual void Update()
    {
        m_currentState.Execute();
    }

    public Rigidbody GetRigidbody()
    {
        if (m_Rigidbody != null)
        {
            return m_Rigidbody;
        }
        else
        {
            Debug.LogError("No RigidBody Found");
        }
        return null;
    }

    public Animator GetAnimator()
    {
        if (m_Animator != null)
        {
            return m_Animator;
        }
        else
        {
            Debug.LogError("No Animator Found");
        }
        return null;
    }

    public SphereCollider GetCollider()
    {
        if (m_Collider != null)
        {
            return m_Collider;
        }
        else
        {
            Debug.LogError("No Collider Found");
        }
        return null;
    }

    public DogData GetDogData()
    {
        if (dogProperties != null)
        {
            return dogProperties;
        }
        else
        {
            Debug.LogError("data is not valid!!!");
            return null;
        }
    }

    public NavMeshAgent GetAgent()
    {
        if (m_Agent != null)
        {
            return m_Agent;
        }
        else
        {
            Debug.LogError("No Navigation Mesh Agent Found");
            return null;
        }
    }
}


















