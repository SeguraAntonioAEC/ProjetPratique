using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DoggySelector : MonoBehaviour
{

    [Header("Currently Controlled Dog"), Space()]
    [SerializeField] private DogStateMachine m_dog;


    [Header("Player's Dog Selection"), Space()]
    private List<DogStateMachine> m_dogsList = new List<DogStateMachine>();
    [SerializeField] private int m_dogInUseID;

    [Header("Cinemachine Camera"), Space()]
    public CinemachineVirtualCamera m_followCam;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform dogTrans = transform.GetChild(i);
            DogStateMachine machine = dogTrans.GetComponent<DogStateMachine>();
            m_dogsList.Add(machine);
            if (i == 0)
            {
                machine.SetState(new PlayerControlled(machine, machine.GetDogData()));
            }
            else
            {
                machine.SetState(new SelfControlled(machine, machine.GetDogData()));
            }
        }
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
            int lastValue = m_dogInUseID;
            if (m_dogInUseID == 0)
            {
                m_dogInUseID = m_dogsList.Count - 1;
            }
            else 
            {
                m_dogInUseID -= 1;   
            }
            Swap(lastValue);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            int lastValue = m_dogInUseID;
            if (m_dogInUseID == m_dogsList.Count - 1)
            {
                m_dogInUseID = 0;
            }
            else
            {
                m_dogInUseID += 1;
            }
            Swap(lastValue);
        }
    }

    public void Swap(int _lastDogValue)
    {
        m_dog = m_dogsList[m_dogInUseID];
        DogStateMachine currentStateMachine = m_dog.GetComponent<DogStateMachine>();
        DogState playerState = currentStateMachine.GetState();

        DogStateMachine _dog = m_dogsList[_lastDogValue];
        DogStateMachine lastStateMachine = _dog.GetComponent<DogStateMachine>();

        currentStateMachine.SetState(new PlayerControlled(currentStateMachine, currentStateMachine.GetDogData()));
        lastStateMachine.SetState(new SelfControlled(lastStateMachine, lastStateMachine.GetDogData()));

        m_followCam.LookAt = m_dog.transform;
        m_followCam.Follow = m_dog.transform;
        Debug.Log("Currently Controlled Dog: " + m_dogsList[m_dogInUseID].ToString());
    }
}
