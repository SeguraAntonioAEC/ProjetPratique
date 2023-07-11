using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    private Dictionary<string, Action<Dictionary<string, object>>> eventsDictionnary;

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
            eventsDictionnary = new Dictionary<string, Action<Dictionary<string, object>>>();
        }
    }


    void StartListening(string eventName, Action listener)
    {
        Action thisEvent;
        if (managerInstance.eventsDictionnary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += listener;
            managerInstance.eventsDictionnary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            managerInstance.eventsDictionnary.Add(eventName, thisEvent);
        }
    }

    void StopListening(string eventName, Action listener)
    {
        if (!eventManager)
        {
            return;
        }

        Action thisEvent;
        if (managerInstance.eventsDictionnary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= listener;
            managerInstance.eventsDictionnary[eventName] = thisEvent;
        }
    }

    void TriggerAction(string eventName)
    {
        Action thisEvent;
        if (managerInstance.eventsDictionnary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
        }
    }
        
}
