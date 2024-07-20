using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Murphy : Dog
{
   [SerializeField] private float m_bashStrenght;
    protected override void  Update()
    {        
        base.Update();
        Bash();            
    }
       
    // Changer la velocité par magnitude de mouvement 

    private void Bash()
    {
        if (Input.GetKeyDown(KeyCode.F) && m_isGrounded == true  && m_isInWater == false && m_dogBody.velocity.x < 0.0f)
        {
            m_dogBody.AddForce(Vector3.right * m_bashStrenght, ForceMode.Impulse);
        }        
    }
}

