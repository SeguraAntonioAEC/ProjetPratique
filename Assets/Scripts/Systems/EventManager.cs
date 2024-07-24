using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public enum EEvents
{
    EVENT_ON_DIG_TRIGGER_ONE,
    EVENT_ON_DIG_TRIGGER_TWO,

}
public class EventManager
{
    private static EventManager m_Instance;
    public static EventManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new EventManager();
            }
            return m_Instance;
        }
    }

    private Dictionary<EEvents, Action<Dictionary<string, object>>> m_Events;

    private EventManager()
    {
        m_Events = new Dictionary<EEvents, Action<Dictionary<string, object>>>();
    }

    public void SubscribeTo(EEvents _EventId, Action<Dictionary<string, object>> _Func)
    {
        if (m_Events.ContainsKey(_EventId))
        {
            m_Events[_EventId] += _Func;
        }
        else
        {
            m_Events.Add(_EventId, _Func);
        }
    }

    public void UnsubscribeTo(EEvents _EventId, Action<Dictionary<string, object>> _Func)
    {
        if (m_Events.ContainsKey(_EventId))
        {
            m_Events[_EventId] -= _Func;
        }
    }

    public void TriggerEvent(EEvents _EventId, Dictionary<string, object> _Parameters)
    {
        if (m_Events.ContainsKey(_EventId))
        {
            m_Events[_EventId].Invoke(_Parameters);
        }
        else
        {
            Debug.Log($"NO {_EventId}");
        }
    }

}
