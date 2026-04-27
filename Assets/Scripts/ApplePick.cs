using UnityEngine;

public class ApplePick : MonoBehaviour
{
    bool picked;
    Animator animator;
    public Transform apple;
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
                Mathf.SmoothStep(apple.position.x, AppleCounter.instance.appleIcon.position.x, counterMoveTime),
                Mathf.SmoothStep(apple.position.y, AppleCounter.instance.appleIcon.position.y, counterMoveTime));

            if (counterMoveTime > 0.5f)
            {
                apple.localScale = new Vector2(
                    Mathf.SmoothStep(1f, 0f, (counterMoveTime - 0.5f) * 2f),
                    Mathf.SmoothStep(1f, 0f, (counterMoveTime - 0.5f) * 2f));
            }
        }
    }

    public void Picked()
    {
        if (!picked)
        {
            picked = true;
            TreeManager.instance.RemoveAppleFromPool(this);
        }
    }

    public void GlintAnimation()
    {
        animator.Play("Glint");
    }

    public void MoveTowardsCounter()
    {
        movingTowardsCounter = true;
    }
}
