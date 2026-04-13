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

        Invoke("GlintRandom", Random.Range(glintDelay.x + 1, glintDelay.y + 1));
    }

    public void AddAppleToPool(ApplePick apple)
    {
        apples.Add(apple);
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
            apples[Random.Range(0, apples.Count)].GlintAnimation(); // min inclusive but max exclusive, so don't substract to get the right upper limit because of course
        }

        Invoke("GlintRandom", Random.Range(glintDelay.x, glintDelay.y));
    }
}
