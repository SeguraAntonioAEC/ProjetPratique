using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DogState 
{
    protected DogStateMachine m_stateMachine;

    protected DogData data;

    public DogState(DogStateMachine stateMachine, DogData _data)
    {
        m_stateMachine = stateMachine;
        data = _data;
    }

    public abstract void Execute();
}
