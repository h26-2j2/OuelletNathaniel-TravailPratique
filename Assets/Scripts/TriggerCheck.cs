using UnityEditor;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public string triggerNameExpect;
    public LayerMask layer;
    public GameEvent enterEvents;
    public GameEvent exitEvents;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.TryGetComponent<TriggerListener>(out TriggerListener listener)
            && listener.triggerName == triggerNameExpect) || collision.gameObject.layer == layer)
        {
            enterEvents.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.TryGetComponent<TriggerListener>(out TriggerListener listener)
            && listener.triggerName == triggerNameExpect) || collision.gameObject.layer == layer)
        {
            exitEvents.Invoke();
        }
    }
}
