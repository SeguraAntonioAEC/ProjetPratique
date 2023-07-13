using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rally : DogStateMachine
{
    [SerializeField] private float m_lightJumpRayLength;
    [SerializeField] private float m_lightJumpForce;
    private bool m_isOnPlatform = false;

    protected override void Update()
    {        
        base.Update();
        Jump();
    }


    public override void Jump()
    {
        RaycastHit surfaceInfo;
        Ray checkSurfaceRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(checkSurfaceRay, out surfaceInfo, m_lightJumpRayLength))
        {
            if (surfaceInfo.collider.tag == "RallyPlatform")
            {
                m_isOnPlatform = true;
                if (Input.GetKeyDown(KeyCode.Space) && m_isOnPlatform)
                {
                    m_dogBody.AddForce(Vector3.up * m_lightJumpForce, ForceMode.Impulse);
                    m_isOnPlatform = false;
                }
            }
            if (surfaceInfo.collider.tag == "Level Ground")
            {
                m_isOnPlatform = true;
                if (Input.GetKeyDown(KeyCode.Space) && m_isOnPlatform)
                {
                    m_dogBody.AddForce(Vector3.up * m_lightJumpForce, ForceMode.Impulse);
                    m_isOnPlatform = false;
                }
            }
        }
    }
}
                