using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    public static TreeManager instance;
    public Vector2 glintDelay;
    List<ApplePick> apples = new List<ApplePick>();

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

        Invoke("GlintRandom", Random.Range(glintDelay.x + 1, glintDelay.y + 1)); // Add a delay in case one of them is 0 and that apples haven't been added to the pool yet
    }

    public void AddAppleToPool(ApplePick apple)
    {
        apples.Add(apple);
        AppleCounter.instance.AddToBaseCounter(false);
    }

    public void RemoveAppleFromPool(ApplePick apple)
    {
        apples.Remove(apple);

        if (apples.Count == 0)
        {

        }
    }

    void GlintRandom()
    {
        if (apples.Count > 0)
        {
            apples[Random.Range(0, apples.Count)].GlintAnimation(); // min inclusive but max exclusive, so don't substract to get the right upper limit because this is *obviously* very intuitive
        }

        Invoke("GlintRandom", Random.Range(glintDelay.x, glintDelay.y));
    }
}
