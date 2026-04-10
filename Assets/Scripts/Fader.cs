using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [SerializeField] Image target;
    [SerializeField] float duration = 1f;
    [SerializeField] AnimationCurve fade;
    [SerializeField] bool fadeOnAwake;
    bool fading;
    float time;

    void Awake()
    {
        if (target == null)
        {
            target = gameObject.GetComponent<Image>();
        }

        if (fadeOnAwake)
        {
            time = 0f;
            StartFading();
        }
    }

    void Update()
    {
        if (fading)
        {
            {
                time += Time.deltaTime / duration;
                time = Mathf.Clamp(time, 0f, 1f);
            }
            target.color = new Color(target.color.r, target.color.g, target.color.b, fade.Evaluate(time));
        }
    }

    public void StartFading()
    {
        fading = true;
    }
}
