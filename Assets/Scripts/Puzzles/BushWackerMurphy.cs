using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BushWackerMurphy : MonoBehaviour
{
    [SerializeField]List<CapsuleCollider> capsuleColliders;
    private bool hasMurphyBashed;

   
    void Start()
    {
       hasMurphyBashed = false;
    }    

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.velocity.magnitude > 2.5f && other.tag == "Murphy" && hasMurphyBashed == false)
        {
            hasMurphyBashed = true;
            capsuleColliders[0].radius = capsuleColliders[0].radius / 2;
            capsuleColliders[1].radius = capsuleColliders[1].radius / 2;
        }
    }
}
