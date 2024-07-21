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



}
