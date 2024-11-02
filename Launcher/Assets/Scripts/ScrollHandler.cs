using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public UnityEvent OnLongDrag;
    public float longDragThreshold = 300f; // Adjust as needed for your long drag threshold
    private ScrollRect scrollRect; // Reference to the ScrollRect component

    private Vector2 dragStartPosition, previousDragPosition;
    private float dragStartTime;
    private bool isDraggingUp;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();

        if (scrollRect != null)
        {
            scrollRect.verticalNormalizedPosition = 1f;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
        previousDragPosition = dragStartPosition;

        dragStartTime = Time.time;
        Debug.Log("Dragging");
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the distance dragged
        float dragDistance = (eventData.position - dragStartPosition).magnitude;
        Vector2 currentDragPosition = eventData.position;
        Vector2 dragDirection = currentDragPosition - previousDragPosition;

        // Check if the drag is moving up or down
        isDraggingUp = dragDirection.y > 0;

        // Update previousDragPosition for the next frame
        previousDragPosition = currentDragPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float dragDuration = Time.time - dragStartTime;

        if (scrollRect.verticalNormalizedPosition >= 1f && dragDuration > longDragThreshold) // Check if we are at the top
        {
            Debug.Log("Long drag detected at the top");
            OnLongDrag.Invoke();
        }

        // Check if the drag is considered "long" and if we are at the top of the ScrollRect
        if (isDraggingUp && dragDuration > 0.2f)
        {
            if (scrollRect.verticalNormalizedPosition >= 1f) // Check if we are at the top
            {
                Debug.Log("Long drag detected at the top");
                OnLongDrag.Invoke();
            }
        }
    }
}
