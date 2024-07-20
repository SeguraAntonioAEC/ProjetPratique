using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum EEvents
{

}
public class EventManager : MonoBehaviour
{
    private Dictionary<EEvents, Action<Dictionary<string, object>>> eventsDictionnary;

    private static EventManager eventManager;

    public static EventManager Instance
    {
        get
        {
            if (eventManager == null)
            {
                eventManager = new EventManager();
            }
            return eventManager;
        }
    }
    private EventManager()
    {
        eventsDictionnary = new Dictionary<EEvents, Action<Dictionary<string, object>>>();
    }
<<<<<<< Updated upstream


    void StartListening(string eventName, Action<Dictionary<string,object>> listener)
    {
=======
<<<<<<< HEAD
    void StartListening(EEvents _event, Action<Dictionary<string,object>> _func)
    {
        if (eventsDictionnary.ContainsKey(_event))
=======


    void StartListening(string eventName, Action<Dictionary<string,object>> listener)
    {
>>>>>>> Stashed changes
        Action<Dictionary<string,object>> thisEvent;
        if (managerInstance.eventsDictionnary.TryGetValue(eventName, out thisEvent))
>>>>>>> f79da9eca8a6f881e59d5e4bdbf358ed978a6f60
        {
            eventsDictionnary[_event] += _func;
        }
        else
        {
            eventsDictionnary.Add(_event, _func);
        }       
    }

<<<<<<< Updated upstream
    void StopListening(string eventName, Action<Dictionary<string, object>> listener)
=======
<<<<<<< HEAD
    void StopListening(EEvents _event, Action<Dictionary<string, object>> _func)
=======
    void StopListening(string eventName, Action<Dictionary<string, object>> listener)
>>>>>>> f79da9eca8a6f881e59d5e4bdbf358ed978a6f60
>>>>>>> Stashed changes
    {
        if (eventsDictionnary.ContainsKey(_event))
        {
<<<<<<< HEAD
            eventsDictionnary[_event] -= _func;
        }       
    }

    void TriggerAction(EEvents _event, Dictionary<string, object> _params)
    {
        if (eventsDictionnary.ContainsKey(_event))
        {
            eventsDictionnary[_event].Invoke(_params);
        }
        else
        {
            Debug.Log($"NO {_event} IN EEvnts");
=======
            return;
        }

        Action<Dictionary<string, object>> thisEvent;
        if (managerInstance.eventsDictionnary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= listener;
            managerInstance.eventsDictionnary[eventName] = thisEvent;
        }
    }

    void TriggerAction(string eventName, Dictionary<string, object> listener)
    {
        Action<Dictionary<string, object>> thisEvent;
        if (managerInstance.eventsDictionnary.TryGetValue(eventName, out thisEvent))
        {            
            thisEvent?.Invoke(listener);
<<<<<<< Updated upstream
=======
>>>>>>> f79da9eca8a6f881e59d5e4bdbf358ed978a6f60
>>>>>>> Stashed changes
        }
        
    }

}
