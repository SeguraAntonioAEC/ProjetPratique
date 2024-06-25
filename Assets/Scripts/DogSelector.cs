using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DogSelector : MonoBehaviour
{
    private static DogSelector m_Instance;

    private DogSelector()
    { 
    }

    [Header("Currently Controlled Dog"), Space()]
    [SerializeField] private DogStateMachine m_dog;
 

    [Header("Player's Dog Selection"), Space()]
    private List<DogStateMachine> m_dogsList = new List<DogStateMachine>();
    [SerializeField] private int m_dogInUseID;

    [Header("Cinemachine Camera"), Space()]
    public CinemachineVirtualCamera m_followCam;

    public static DogSelector Instance => m_Instance;

    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i) {
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
                machine.GetAgent().enabled = true;
            }
        }           
    }

    // Update is called once per frame
    void Update()
    {
        DogSwapper();
        if (m_dog != null)
        { 
            transform.position = m_dog.transform.position;        
        }
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

    public void Swap(int lastDogValue)
    {
        m_dog = m_dogsList[m_dogInUseID];
        DogStateMachine currentStateMachine = m_dog.GetComponent<DogStateMachine>();
        DogState playerState = currentStateMachine.GetState();
        
        DogStateMachine _dog = m_dogsList[lastDogValue];
        DogStateMachine lastStateMachine = _dog.GetComponent<DogStateMachine>();
      
        currentStateMachine.SetState(new PlayerControlled(currentStateMachine, currentStateMachine.GetDogData()));
        lastStateMachine.SetState(new SelfControlled(lastStateMachine, lastStateMachine.GetDogData()));

        m_followCam.LookAt = m_dog.transform;
        m_followCam.Follow = m_dog.transform;
        Debug.Log("Currently Controlled Dog: " + m_dogsList[m_dogInUseID].ToString());
    }


}
