using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogStateMachine : MonoBehaviour
{
    DogState m_currentState;

    private void Start()
    {
        m_currentState = new PlayerControlled(this);
    }

    public void SetState(DogState state)
    {
        m_currentState = state;
    }

    private void Update()
    {
        m_currentState.Execute();
    }

}

  

   
            

    

     




    


        

