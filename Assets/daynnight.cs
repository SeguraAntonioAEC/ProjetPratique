using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class daynnight : MonoBehaviour
{
    private Light m_DirectionalLight;

    private float lightIntesity = 0.0f;
    void Start()
    {
        m_DirectionalLight = GetComponent<Light>();
    }
    
    
    void Update()
    {
        LightCycle(); 
    }

    void LightCycle()
    {
        m_DirectionalLight.intensity = Mathf.Lerp(0f,1, Time.time);
    }
}
