using UnityEngine;

public class Apple : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        AppleManager.instance.AddAppleToPool(this);
    }

    public void GlintAnimation()
    {
        animator.Play("Glint");
    }
}
