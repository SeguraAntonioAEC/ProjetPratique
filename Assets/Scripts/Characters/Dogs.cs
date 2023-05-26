using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dogs : MonoBehaviour
{
    public Rigidbody m_dogBody;

    //Dogs movement and physics:
    [SerializeField] protected float m_dogSpeed;

    [SerializeField] protected float m_dogSwimSpeed;

    [SerializeField] protected float m_jumpForce;

    [SerializeField] protected float m_swimMaxDistance;

    [SerializeField] protected float m_rayLength;

    protected Vector3 m_lastSafePosition;

    protected bool m_isGrounded = true;

    protected bool m_isMoving = false;

    protected bool m_isInWater = false;

    protected bool m_isSafe = true;

    protected Vector3 m_waterSurfacePos;

    // Water Behaviour variables:

    [SerializeField] protected float m_submersionThreshold;

    [SerializeField] protected float m_dispalcementRate;
    


    void Awake()
    {
        m_dogBody = GetComponent<Rigidbody>();
    }    

    protected virtual void Update()
    {
        
        PositionReset();
        BasicMovement();
        WaterMovement();
        Jump();
        Sprint();
        SurfaceCheck();

    }
    public void BasicMovement()
    {
        if (!m_dogBody) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 velocity = m_dogBody.velocity;
        velocity.x = m_dogSpeed * horizontalInput;
        velocity.z = m_dogSpeed * verticalInput;
        m_dogBody.velocity = velocity;
        if (m_dogBody.velocity.x > 0.0f || m_dogBody.velocity.x < 0.0f)
        {
            m_isMoving = true;
        }
        else
        {
            m_isMoving = false; 
        }
    }

    public void WaterMovement()
    {
        if (!m_dogBody) return;
        if (m_isInWater)
        {
            if (m_dogBody.position.y < m_waterSurfacePos.y)
            {
                float displacementMultiplier = Mathf.Clamp01(-transform.position.y / m_submersionThreshold) * m_dispalcementRate;
                m_dogBody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
            }            
        }
    }     
    public void Sprint()
    {
        if (!m_dogBody) return;
        if (m_isMoving && Input.GetKey(KeyCode.LeftShift))
        {
            m_dogBody.velocity = m_dogBody.velocity * 2.0f;
        }
    }
    public virtual void Jump()
    {
        if (!m_dogBody) return;
        if (Input.GetKeyDown(KeyCode.Space) && m_isGrounded)
        {
            m_dogBody.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_isGrounded = false;
        }
    }

    public void SurfaceCheck()
    {
        RaycastHit surfaceInfo;
        Ray checkSurfaceRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(checkSurfaceRay, out surfaceInfo ,m_rayLength))
        {
            if (surfaceInfo.collider == false)
            {
                m_isGrounded = false;
                m_isInWater = false;
            }
            if (surfaceInfo.collider.tag == "Level Ground")
            {
                SetLastSafePosition();
                m_isGrounded = true;
                m_isInWater = false;
                m_waterSurfacePos = new Vector3(-1.0f, -1.0f, -30.0f);
            }
            if (surfaceInfo.collider.tag == "Water")
            {
                m_isInWater = true;
                m_isGrounded = false;
                m_waterSurfacePos = surfaceInfo.collider.transform.position;
            }
            Debug.DrawRay(transform.position, Vector3.down, Color.red, 5.0f);
        }       
    }
    public void Bite()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter
        //check if is at rage 
    }

    public void BiteAndTug()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter
        //check if is at rage 
    }

    public void Bark()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter
        //check if is at rage 
    }

    public void Dig()
    {
        //use mouse to screen raycast to determine if is on click trigger 
        //set on click enter 
        //check if is in range 
    }
    public void PositionReset() 
    {
        if (transform.position.y <= -0.5f)
        {
            m_isSafe = false;
        }
        if (m_isSafe == false && transform.position.y <= -1.0f)
        {
            transform.position = m_lastSafePosition;
            m_isSafe = true;
        }
    }
    public void SetLastSafePosition()
    {        
        if (m_isGrounded && transform.position.y >= 0.0f)
        {
            m_lastSafePosition = transform.position; 
        }
    }
}

  

   
            

    

     




    


        

