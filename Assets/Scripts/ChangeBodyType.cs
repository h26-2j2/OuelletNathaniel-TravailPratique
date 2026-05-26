using UnityEngine;

public class ChangeBodyType : MonoBehaviour
{
    public void SetDynamic(Rigidbody2D target)
    {
        target.bodyType = RigidbodyType2D.Dynamic;
    }
    public void SetKinematic(Rigidbody2D target)
    {
        target.bodyType = RigidbodyType2D.Kinematic;
    }
    public void SetStatic(Rigidbody2D target)
    {
        target.bodyType = RigidbodyType2D.Static;
    }
}
