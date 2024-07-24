using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class SelfControlled : DogState
{
    public SelfControlled(DogStateMachine stateMachine, DogData _data) : base(stateMachine, _data)
    {
     
        m_stateMachine.GetAnimator().SetFloat("Movement_f", 0);
    }

    public override void Execute()
    {   
        


    }

    void FollowLead(Vector3 _packLeaderPos)
    {          
        //m_stateMachine.GetAgent().destination = _packLeaderPos;

        //Vector3 currentVelocity = m_stateMachine.GetAgent().velocity;
        //float movementMagnitude = (currentVelocity- Vector3.up * currentVelocity.y).magnitude;
        //if (movementMagnitude > 0.0f)
        //{
        //    Vector3 tempVector = m_stateMachine.GetAgent().transform.position + currentVelocity;
        //    tempVector.y = m_stateMachine.GetAgent().transform.position.y;
        //    m_stateMachine.GetRigidbody().transform.LookAt(tempVector);
        //    data.isMoving = true;
        //}       
       
    }

    void PlayIdleRandAnim()
    {
        // needs timer 
        // needs anim options list 
        // needs trigger 
        // if certain time f inactivity play random Idle anim 
    }
}
