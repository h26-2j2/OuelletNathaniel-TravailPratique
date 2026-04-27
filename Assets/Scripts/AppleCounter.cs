using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AppleCounter : MonoBehaviour
{
    public static AppleCounter instance;
    public int counter;
    public int counterMax;
    public TMP_Text counterText;
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
    }

    void Update()
    {
        counterText.text = counter + "/" + counterMax;
    }

    public void AddToBaseCounter(bool addValue = false)
    {
        counterMax++;
        if (addValue) { counter++; }
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
    }
}
