using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DogSelector : MonoBehaviour
{
    
    public Transform m_dog;
    public List<Transform> m_dogsList;
    public int m_dogInUse;
    public CinemachineVirtualCamera m_followCam; 

    void Start()
    {
        if (!m_dog && m_dogsList.Count >= 1)
        {
            m_dog = m_dogsList[0];
        }
        Swap();
    }

    // Update is called once per frame
    void Update()
    {
        DogSwapper();
    }

    void DogSwapper()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (m_dogInUse == 0)
            {
                m_dogInUse = m_dogsList.Count - 1;
            }
            else 
            {
                m_dogInUse -= 1;
            }            
            Swap();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (m_dogInUse == m_dogsList.Count -1)
            {
                m_dogInUse = 0;
            }
            else
            {
                m_dogInUse += 1;
            }
            Swap();
        }
    }

    public void Swap()
    {
        m_dog = m_dogsList[m_dogInUse];
        m_dog.GetComponent<Dogs>().enabled = true;
        for (int i = 0; i < m_dogsList.Count; i++)
        {
            if (m_dogsList[i] != m_dog)
            {
                m_dogsList[i].GetComponent<Dogs>();
                m_dogsList[i].GetComponent<Dogs>().enabled = false;
            }
        }
        m_followCam.LookAt = m_dog;
        m_followCam.Follow = m_dog;
        Debug.Log("DogInUse" + m_dogInUse);
    }
}
