using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBuoyancy : MonoBehaviour
{
    private Transform m_waterTransform;
    private float m_initialPosY;
    

    
    void Start()
    {
        m_waterTransform = GetComponent<Transform>();
        m_initialPosY = m_waterTransform.position.y;
    }
    
    void Update()
    {
        float posY = m_waterTransform.position.y;
        posY = Mathf.PingPong(Time.time / 5f, 0.1f);
        m_waterTransform.position = new Vector3(m_waterTransform.position.x, m_initialPosY + posY, m_waterTransform.position.z);
    }
}

