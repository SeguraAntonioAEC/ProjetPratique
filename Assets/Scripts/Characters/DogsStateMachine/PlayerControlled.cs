using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : DogState
{  
        
    public PlayerControlled(DogStateMachine stateMachine, DogData _data) : base(stateMachine, _data)
    {       
        data.lastSafePosition = m_stateMachine.transform.position;

        if (m_stateMachine.GetAgent() != null)
        { 
            m_stateMachine.GetAgent().enabled = false;        
        }
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
        if (!m_stateMachine.GetRigidbody()) return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 velocity = m_stateMachine.GetRigidbody().velocity;
        velocity.x = data.dogSpeed * horizontalInput;
        velocity.z = data.dogSpeed * verticalInput;
        m_stateMachine.GetRigidbody().velocity = velocity;

        float movementMagnitude = (m_stateMachine.GetRigidbody().velocity - Vector3.up * m_stateMachine.GetRigidbody().velocity.y).magnitude;

        if (movementMagnitude > 0.0f)
        {
            Vector3 tempVector = m_stateMachine.GetRigidbody().transform.position + velocity;
            tempVector.y = m_stateMachine.GetRigidbody().transform.position.y;
            m_stateMachine.GetRigidbody().transform.LookAt(tempVector);
            data.isMoving = true;
        }
        else
        {
            data.isMoving = false;
        }
        m_stateMachine.GetAnimator().SetFloat("Movement_f", movementMagnitude);
    }
    public void Sprint()
    {
        if (!m_stateMachine.GetRigidbody()) return;
        if (data.isMoving && Input.GetKeyDown(KeyCode.LeftShift))
        {
            m_stateMachine.GetRigidbody().velocity = m_stateMachine.GetRigidbody().velocity * 2.0f;
        }
    }
    public virtual void Jump()
    {
        if (!m_stateMachine.GetRigidbody()) return;
        if (Input.GetKeyDown(KeyCode.Space) && data.isGrounded)
        {
            m_stateMachine.GetRigidbody().AddForce(Vector3.up * data.jumpForce, ForceMode.Impulse);
            data.isGrounded = false;
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
        //        data.m_isGrounded = false;
        //        m_isInWater = false;
        //    }
        //    if (surfaceInfo.collider.tag == "Level Ground")
        //    {
        //        SetLastSafePosition();
        //        data.m_isGrounded = true;
        //        m_isInWater = false;               
        //    }
        //    if (surfaceInfo.collider.tag == "Water")
        //    {
        //        m_isInWater = true;
        //        data.m_isGrounded = false;                
        //    }
        //    Debug.DrawRay(transform.position, Vector3.down, Color.red, 5.0f);
        //}
        //if (Physics.Raycast(checkSlope, out surfaceInfo, m_slopeRay))
        //{
        //    if (surfaceInfo.collider == false)
        //    {
        //        data.m_isGrounded = false;
        //        m_isInWater = false;
        //    }
        //    if (surfaceInfo.collider.tag == "Level Ground")
        //    {
        //        SetLastSafePosition();
        //        data.m_isGrounded = true;
        //        m_isInWater = false;
        //    }
        //    if (surfaceInfo.collider.tag == "Water")
        //    {
        //        m_isInWater = true;
        //        data.m_isGrounded = false;
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
            data.isSafe = false;
        }
        if (data.isSafe == false && m_stateMachine.transform.position.y <= -1.0f)
        {
            m_stateMachine.transform.position = data.lastSafePosition;
            data.isSafe = true;
        }
    }
    public void SetLastSafePosition()
    {
        if (data.isGrounded && m_stateMachine.transform.position.y >= 0.0f)
        {
            data.lastSafePosition = m_stateMachine.transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Level Ground")
        {
            data.isGrounded = true;
            data.isSafe = true;
        }
        if (collision.gameObject.tag == "Water")
        {
            data.isInWater = true;
            data.isGrounded = false;
        }
    }
}

