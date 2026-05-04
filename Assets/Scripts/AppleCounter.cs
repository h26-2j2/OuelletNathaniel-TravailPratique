using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleCounter : MonoBehaviour
{
    public static AppleCounter instance;
    public int counter;
    public int counterMax;
    public TMP_Text counterText;
    string counterBaseText;
    public Transform appleIcon;

    void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        counterBaseText = counterText.text;
    }

    void UpdateCounter(bool textOnly = false)
    {
        counterText.text = counterBaseText + counter + "/" + counterMax;
        if (textOnly) { return; } // Skip the rest if only wanting to update the text as defined by adding true when calling this function

    }

    public void AddToBaseCounter(bool addValue = false)
    {
        counterMax++;
        if (addValue) { counter++; }
        UpdateCounter(true);
    }

    public void changeCounter(bool reduce = false)
    {
        if (reduce)
        {
            counter--;

            if (counter <= 0)
            {
                gameObject.GetComponent<ObjectEvent>().TriggerEvents();
            }
        }
        else
        {
            counter++;

            if (counter >= counterMax)
            {
                gameObject.GetComponent<ObjectEvent>().TriggerEvents();
            }
        }
        UpdateCounter();
    }
}
