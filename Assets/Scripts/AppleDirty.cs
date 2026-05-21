using UnityEngine;

public class AppleDirty : MonoBehaviour
{
    float dirtiness = 100f;
    public float cleanSpeed = 25f;
    public bool isCleaning = false;
    public bool cleaned = false;
    public GameEvent onCleaned;
    [Space(8)]
    public SpriteRenderer spriteDirtyBase;
    Color colorDirtyBaseOrigin;
    public Color colorDirtyBaseTarget;
    public SpriteRenderer spriteDirtyLight;
    Color colorDirtyLightOrigin;
    public Color colorDirtyLightTarget;
    public SpriteRenderer spriteDirt;
    Color colorDirtOrigin;
    public Color colorDirtTarget;
    public SpriteRenderer spriteClean;

    private void Start()
    {
        colorDirtyBaseOrigin = spriteDirtyBase.color;
        colorDirtyLightOrigin = spriteDirtyLight.color;
        colorDirtOrigin = spriteDirt.color;
    }

    private void Update()
    {
        if (isCleaning && !cleaned)
        {
            dirtiness -= cleanSpeed * Time.deltaTime;
            if (dirtiness <= 0) { Cleaned(); return; }

            float cleanliness = 1f - dirtiness / 100f;

            // Horrible, just horrible. No excuse this is awful.
            spriteDirtyBase.color = new Color(Mathf.Lerp(colorDirtyBaseOrigin.r, colorDirtyBaseTarget.r, cleanliness),
                                              Mathf.Lerp(colorDirtyBaseOrigin.g, colorDirtyBaseTarget.g, cleanliness),
                                              Mathf.Lerp(colorDirtyBaseOrigin.b, colorDirtyBaseTarget.b, cleanliness),
                                              Mathf.Lerp(colorDirtyBaseOrigin.a, colorDirtyBaseTarget.a, cleanliness));
            spriteDirtyLight.color = new Color(Mathf.Lerp(colorDirtyLightOrigin.r, colorDirtyLightTarget.r, cleanliness),
                                               Mathf.Lerp(colorDirtyLightOrigin.g, colorDirtyLightTarget.g, cleanliness),
                                               Mathf.Lerp(colorDirtyLightOrigin.b, colorDirtyLightTarget.b, cleanliness),
                                               Mathf.Lerp(colorDirtyLightOrigin.a, colorDirtyLightTarget.a, cleanliness));
            spriteDirt.color = new Color(Mathf.Lerp(colorDirtOrigin.r, colorDirtTarget.r, cleanliness),
                                         Mathf.Lerp(colorDirtOrigin.g, colorDirtTarget.g, cleanliness),
                                         Mathf.Lerp(colorDirtOrigin.b, colorDirtTarget.b, cleanliness),
                                         Mathf.Lerp(colorDirtOrigin.a, colorDirtTarget.a, cleanliness));
        }
    }

    public void Cleaned()
    {
        cleaned = true;
        onCleaned.Invoke();
    }
}
