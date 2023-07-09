using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action> eventsDictionnary;

    private static EventManager eventManager;

    public static EventManager managerInstance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType<EventManager>();

                if (!eventManager)
                {
                    Debug.LogError("No event manager found");
                }
                else 
                {
                    eventManager.Init();
                    DontDestroyOnLoad(eventManager);
                }
            }
         return eventManager;
        }
    }

    private void Init()
    {
        if (eventsDictionnary == null)
        {
            eventsDictionnary = new Dictionary<string, Action>();
        }
    }


    void StartListening()
    {
    }

    void StopListening()
    { 
    }

    void TriggerAction()
    { 
    }
        
}
