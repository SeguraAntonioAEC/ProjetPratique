using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_animator.Play("PiggyGrab");

        }
    }

    private void SelfDestruct()
    {
        Destroy(gameObject);
    }
}
