using UnityEngine;

public class ApplePick : MonoBehaviour
{
    bool picked;
    Animator animator;
    public Transform apple;
    public Vector2 appleOrigin;
    public GameObject glint;
    bool movingTowardsCounter = false;
    float counterMoveTime;
    public float counterMoveDuration = 5f;

    void Start()
    {
        TreeManager.instance.AddAppleToPool(this);
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (movingTowardsCounter)
        {
            counterMoveTime += Time.deltaTime / counterMoveDuration;

            apple.position = new Vector2(
                Mathf.SmoothStep(appleOrigin.x, AppleCounter.instance.appleIcon.position.x, counterMoveTime),
                Mathf.SmoothStep(appleOrigin.y, AppleCounter.instance.appleIcon.position.y, counterMoveTime));

            apple.localScale = new Vector2(
                Mathf.SmoothStep(1f, 0f, (counterMoveTime * 2f) - 1f),
                Mathf.SmoothStep(1f, 0f, (counterMoveTime * 2f) - 1f));

            if (counterMoveTime >= 1f)
            {
                AppleCounter.instance.changeCounter();
                movingTowardsCounter = false;
                apple.localScale = new Vector2(0f, 0f);
            }
        }
    }

    public void Picked()
    {
        if (!picked)
        {
            picked = true;
            glint.SetActive(false);
            TreeManager.instance.RemoveAppleFromPool(this);
        }
    }

    public void GlintAnimation()
    {
        animator.Play("Glint");
    }

    public void MoveTowardsCounter()
    {
        appleOrigin = apple.position; // Save current position so the transition working in relation to the counter's apple can have something to work with
        movingTowardsCounter = true;
    }
}
