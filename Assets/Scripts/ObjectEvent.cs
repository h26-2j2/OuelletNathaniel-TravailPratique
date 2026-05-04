using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEvent : MonoBehaviour
{
    public bool oneTime;
    [InspectorName("Don't Activate on Enable")]
    public bool activateOnAwake;
    public bool activateOnEnable;
    public float delay;
    bool activated;

    public bool loop;
    public float loopTime = 0.5f;
    public bool loopFinite;
    public int loopAmount = 1;
    int loopCount;

    [Space(8)]
    public GameEvent events;

    // This is a script I made some time ago for my own game, it builds off "GameEvent" and makes it something you can access in the editor and call to and from very easily.
    // Helps streamline some stuff that would otherwise be annoying or redundant to add in other scripts by implementing the logic in the inspector instead.

    void Awake()
    {
        if (activateOnAwake)
        {
            Invoke("Activate", delay);
        }
    }

    void OnEnable()
    {
        if (activateOnEnable)
        {
            Invoke("Activate", delay);
        }
    }

    public void TriggerEvents()
    {
        Invoke("Activate", delay);
    }

    void Activate()
    {
        if (gameObject.activeSelf && (!activated || !oneTime))
        {
            activated = true;
            events.Invoke();
            if (loop && (!loopFinite || loopCount < loopAmount))
            {
                Debug.Log("Looped " + (loopCount + 1) + " time");
                loopCount++;
                Invoke("LoopActivate", loopTime);
            }
        }
    }

    void LoopActivate()
    {
        if (!loopFinite || loopCount < loopAmount)
        {
            events.Invoke();
            Debug.Log("Looped " + (loopCount + 1) + " time");
            loopCount++;
            Invoke("LoopActivate", loopTime);
        }
    }
}