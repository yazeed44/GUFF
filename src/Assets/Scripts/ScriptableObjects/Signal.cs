using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OOP pattern here, the observer pattern
[CreateAssetMenu]
public class Signal : ScriptableObject
{
    public List<SignalListener> listeners = new List<SignalListener>();

    // AKA onEvenT()
    public void Raise()
    {
        for(int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnSignalRaised();
        }
    }

    public void RegisterListener(SignalListener listener)
    {
        listeners.Add(listener);
    }

    public void DeRegisterListener(SignalListener listener)
    {
        listeners.Remove(listener);
    }
}
