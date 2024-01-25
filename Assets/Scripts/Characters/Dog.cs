using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    protected Rigidbody m_rigidBody;

    [Header("derniere position sûre")]
    protected Vector3 m_lastSafePosition;

    [Header("Variables De mouvement")] 
    
    [SerializeField][Range(0.0f, 10.0f)] protected float m_dogSpeed;

    [SerializeField][Range(0.0f, 10.0f)] protected float m_jumpForce;
    
    [Space(5)]

    [Header("Variables Pour la Nage")]

    [SerializeField][Tooltip("Temps que le chien peux nager avant d'être ramenné en lieu sûr")] protected float m_swimEndurance;

    [Space(5)]

    [Header("Ajustement Des RayCast")]

    [SerializeField][Tooltip("rayon pointé vers le sol")] protected float m_groundRayLenght;

    [SerializeField][Tooltip("rayon qui pointe vers le devant du pesonnage")] protected float m_slopeRayLenght;

    [Header("Booleens")]

    protected bool m_isMoving;

    protected bool m_isGrounded;

    protected bool m_isInWater;

    protected bool m_isSafe;


    protected DogStateMachine m_stateMachine;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
