using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DogData
{
    public float dogSpeed;

    public float dogSwimSpeed;

    public float jumpForce;

    public float swimMaxDistance;

    [Header("RaycastLenghts")]
    public float rayLength;

    public float slopeRay;

    [Header("Position reset vector")]
    public Vector3 lastSafePosition;

    [Header("State Used Booleans")]
    public bool isGrounded;

    public bool isMoving;

    public bool isInWater;

    public bool isSafe;
}
