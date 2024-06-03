using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine.AI;
using UnityEngine;

public class SelfControlled : DogState
{
    public SelfControlled(DogStateMachine stateMachine, DogData _data) : base(stateMachine, _data)
    { 
        m_stateMachine.GetAgent().enabled = true;
    }

    public override void Execute()
    {
        Debug.Log("execute in AI");
    }

    void FollowLead()
    { 
       // follow player controlled dog If no coroutine is active
        
    }

    void PlayIdleRandAnim()
    {
        // if certain time f inactivity play random Idle anim 
    }
}
