using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GameEvent
{
    public GameObject[] toActivateObjects;
    [Space(6)]
    public GameObject[] toDisActivateObjects;
    [Space(23)]
    public UltEvents.UltEvent onActivate;
    [Space(6)]
    public UltEvents.UltEvent onDisActivate;

    // This is a script I made some time ago for my own game, you can integrate it into another script to handle events.

    public void Invoke()
    {
        if (toDisActivateObjects != null)
        {
            foreach (GameObject gameObject in toDisActivateObjects)
            {
                if (gameObject)
                {
                    gameObject.SetActive(false);
                }
            }
        }
        if (toActivateObjects != null)
        {
            foreach (GameObject gameObject2 in toActivateObjects)
            {
                if (gameObject2)
                {
                    gameObject2.SetActive(true);
                }
            }
        }
        UltEvents.UltEvent unityEvent = onActivate;
        if (unityEvent == null)
        {
            return;
        }
        unityEvent.Invoke();
    }

    public void Revert()
    {
        if (toDisActivateObjects != null)
        {
            foreach (GameObject gameObject in toDisActivateObjects)
            {
                if (gameObject)
                {
                    gameObject.SetActive(true);
                }
            }
        }
        if (toActivateObjects != null)
        {
            foreach (GameObject gameObject2 in toActivateObjects)
            {
                if (gameObject2)
                {
                    gameObject2.SetActive(false);
                }
            }
        }
        UltEvents.UltEvent unityEvent = onDisActivate;
        if (unityEvent == null)
        {
            return;
        }
        unityEvent.Invoke();
    }
}