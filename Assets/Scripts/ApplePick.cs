using UnityEngine;

public class ApplePick : MonoBehaviour
{
    bool picked;
    Animator animator;


    void Start()
    {
        TreeManager.instance.AddAppleToPool(this);
        animator = GetComponentInChildren<Animator>();
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
}
