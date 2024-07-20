using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BushWackerMurphy : MonoBehaviour
{
    BoxCollider m_treeCollider; 

   
    void Start()
    {
        m_treeCollider = GetComponent<BoxCollider>();
    }

  
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 3.5f && collision.collider.name == "Murphy")
        {
           m_treeCollider.enabled = false;
        }
    }
}
