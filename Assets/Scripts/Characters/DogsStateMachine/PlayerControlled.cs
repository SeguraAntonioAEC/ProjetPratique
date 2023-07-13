using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : DogState
{
    protected Rigidbody m_dogBody;

    protected Animator m_dogAnimator;

    //DogStateMachine movement and physics:
    [SerializeField] protected float m_dogSpeed;

    [SerializeField] protected float m_dogSwimSpeed;

    [SerializeField] protected float m_jumpForce;

    [SerializeField] protected float m_swimMaxDistance;

    [SerializeField] protected float m_rayLength;

    [SerializeField] protected float m_slopeRay;

    protected Vector3 m_lastSafePosition;

    protected bool m_isGrounded = true;

    protected bool m_isMoving = false;

    protected bool m_isInWater = false;

    protected bool m_isSafe = true;

    public PlayerControlled(DogStateMachine stateMachine) : base(stateMachine)
    {
        m_dogBody = m_stateMachine.GetComponent<Rigidbody>();
        m_dogAnimator =m_stateMachine.GetComponent<Animator>();
        m_lastSafePosition = m_stateMachine.transform.position;
    }

    public override void Execute()
    {
        PositionReset();
        BasicMovement();
        Jump();
        Sprint();
        SurfaceCheck();
    }
    public void BasicMovement()
    {
        if (!m_dogBody) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 velocity = m_dogBody.velocity;
        velocity.x = m_dogSpeed * horizontalInput;
        velocity.z = m_dogSpeed * verticalInput;
        m_dogBody.velocity = velocity;
        float movementMagnitude = (m_dogBody.velocity - Vector3.up * m_dogBody.velocity.y).magnitude;
        if (movementMagnitude > 0.0f)
        {
            Vector3 tempVector = m_dogBody.transform.position + velocity;
            tempVector.y = m_dogBody.transform.position.y;
            m_dogBody.transform.LookAt(tempVector);
            m_isMoving = true;
        }
        else
        {
            m_isMoving = false;
        }
        m_dogAnimator.SetFloat("Movement_f", movementMagnitude);
    }
    public void Sprint()
    {
        if (!m_dogBody) return;
        if (m_isMoving && Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_dogBody.velocity = m_dogBody.velocity * 2.0f;
        }
    }
    public virtual void Jump()
    {
        if (!m_dogBody) return;
        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
        {
            m_dogBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_isGrounded = false;
        }
    }

    public void SurfaceCheck()
    {
        //RaycastHit surfaceInfo;
        //Ray checkSurfaceRay = new Ray(transform.position - Vector3.down * transform.position.y, Vector3.down);
        //Ray checkSlope = new Ray(transform.position - Vector3.down * transform.position.y,transform.forward);
        //if(Physics.Raycast(checkSurfaceRay, out surfaceInfo ,m_rayLength))
        //{
        //    if (surfaceInfo.collider == false)
        //    {
        //        m_isGrounded = false;
        //        m_isInWater = false;
        //    }
        //    if (surfaceInfo.collider.tag == "Level Ground")
        //    {
        //        SetLastSafePosition();
        //        m_isGrounded = true;
        //        m_isInWater = false;               
        //    }
        //    if (surfaceInfo.collider.tag == "Water")
        //    {
        //        m_isInWater = true;
        //        m_isGrounded = false;                
        //    }
        //    Debug.DrawRay(transform.position, Vector3.down, Color.red, 5.0f);
        //}
        //if (Physics.Raycast(checkSlope, out surfaceInfo, m_slopeRay))
        //{
        //    if (surfaceInfo.collider == false)
        //    {
        //        m_isGrounded = false;
        //        m_isInWater = false;
        //    }
        //    if (surfaceInfo.collider.tag == "Level Ground")
        //    {
        //        SetLastSafePosition();
        //        m_isGrounded = true;
        //        m_isInWater = false;
        //    }
        //    if (surfaceInfo.collider.tag == "Water")
        //    {
        //        m_isInWater = true;
        //        m_isGrounded = false;
        //    }
        //    Debug.DrawRay(transform.position -Vector3.back, transform.forward, Color.red, 5.0f);
        //}
    }
    public void Bite()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter
        //check if is at rage 
    }

    public void BiteAndTug()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter
        //check if is at rage 
    }

    public void Bark()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter
        //check if is at rage 
    }

    public void Dig()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter 
        //check if is in range 
    }
    public void PositionReset()
    {
        if (m_stateMachine.transform.position.y <= -0.5f)
        {
            m_isSafe = false;
        }
        if (m_isSafe == false && m_stateMachine.transform.position.y <= -1.0f)
        {
            m_stateMachine.transform.position = m_lastSafePosition;
            m_isSafe = true;
        }
    }
    public void SetLastSafePosition()
    {
        if (m_isGrounded && m_stateMachine.transform.position.y >= 0.0f)
        {
            m_lastSafePosition = m_stateMachine.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level Ground")
        {
            m_isGrounded = true;
            m_isSafe = true;
        }
        if (collision.gameObject.tag == "Water")
        {
            m_isInWater = true;
            m_isGrounded = false;
        }
    }
}

