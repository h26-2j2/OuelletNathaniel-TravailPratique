using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    public static AppleManager instance;
    public Vector2 glintDelay;
    List<Apple> apples = new List<Apple>();
    public Vector2 worldBordersX;
    public Vector2 worldBordersY;
    BoxCollider2D worldBorders;

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

        if (gameObject.TryGetComponent<BoxCollider2D>(out worldBorders))
        {
            worldBordersX = new Vector2(worldBorders.bounds.min.x, worldBorders.bounds.max.x);
            worldBordersY = new Vector2(worldBorders.bounds.min.y, worldBorders.bounds.max.y);
        }

        Invoke("GlintRandom", Random.Range(glintDelay.x + 1, glintDelay.y + 1)); // Add a delay in case one of them is 0 and that apples haven't been added to the pool yet
    }

    public void AddAppleToPool(Apple apple)
    {
        apples.Add(apple);
        AppleCounter.instance.AddToBaseCounter(false);
    }

    public void RemoveAppleFromPool(Apple apple)
    {
        apples.Remove(apple);
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
