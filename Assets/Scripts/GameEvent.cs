using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GameEvent
{
    public GameObject[] toActivateObjects;
    [Space(4)]
    public GameObject[] toDisActivateObjects;
    [Space(6)]
    // public UltEvent onActivate; // Better version of unity events, good library
    public UnityEvent onActivateEvents;

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

        if (onActivateEvents == null)
        {
            return;
        }
        onActivateEvents.Invoke();
    }
}