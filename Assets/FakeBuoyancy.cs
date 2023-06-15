using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBuoyancy : MonoBehaviour
{
    private Transform m_waterTransform;
    private float m_initialPosY;
    [SerializeField]private float m_OscillationTime = 0.01f;
    [SerializeField] private float m_oscillationRate= 5f;

    
    void Start()
    {
        m_waterTransform = GetComponent<Transform>();
        m_initialPosY = m_waterTransform.position.y;
    }
    
    void Update()
    {
        float posY = m_waterTransform.position.y;
        posY = Mathf.PingPong(Time.time / m_oscillationRate, m_OscillationTime);
        m_waterTransform.position = new Vector3(m_waterTransform.position.x, m_initialPosY + posY, m_waterTransform.position.z);
    }
}

