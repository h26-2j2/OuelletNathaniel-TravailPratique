using UnityEngine;
using UnityEngine.EventSystems;

public class DragableObject : MonoBehaviour
{
    Vector3 origin;
    Collider2D objectCollider;
    public GameEvent dragStart;
    public GameEvent dragEnd;

    void Start()
    {
        origin = transform.position;
        objectCollider = GetComponent<Collider2D>();
    }

    public void OnDragStart(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null)
        {
            Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(pointerData.position);

            // Limit the object to a set border around the center of the world. This solution is absolutely not scalable but that's fine
            transform.position = new Vector2(
                Mathf.Clamp(pointerPosition.x, AppleManager.instance.worldBordersX.x, AppleManager.instance.worldBordersX.y),
                Mathf.Clamp(pointerPosition.y, AppleManager.instance.worldBordersY.x, AppleManager.instance.worldBordersY.y));
            objectCollider.enabled = false;
            dragStart.Invoke();
        }
    }

    public void OnDrag(BaseEventData eventData)
    {
        PointerEventData pointerData = eventData as PointerEventData;
        if (pointerData != null)
        {
            Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(pointerData.position);
            transform.position = new Vector2(
                Mathf.Clamp(pointerPosition.x, AppleManager.instance.worldBordersX.x, AppleManager.instance.worldBordersX.y),
                Mathf.Clamp(pointerPosition.y, AppleManager.instance.worldBordersY.x, AppleManager.instance.worldBordersY.y));
        }
    }

    public void OnDragEnd(BaseEventData eventData)
    {
        dragEnd.Invoke();
    }

    public void MoveToOrigin()
    {
        transform.position = origin;
    }
}