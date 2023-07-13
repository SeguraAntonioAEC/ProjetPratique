using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DogState 
{
    protected DogStateMachine m_stateMachine;

    public DogState(DogStateMachine stateMachine)
    {
        m_stateMachine = stateMachine;
    }

    public abstract void Execute();
}
