using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine.AI;
using UnityEngine;

public class SelfControlled : DogState
{
    //composantes de l'IA ?


    public SelfControlled(DogStateMachine stateMachine, DogData _data) : base(stateMachine, _data)
    { 
        m_stateMachine.GetAgent().enabled = true;
    }

    public override void Execute()
    {
       
    }

    void FollowLead()
    { 
       // follow player controlled dog If no coroutine is active
        
    }

    void PlayIdleRandAnim()
    {
        
    }
}
