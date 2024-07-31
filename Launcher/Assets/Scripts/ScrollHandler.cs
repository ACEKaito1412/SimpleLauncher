using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ScrollHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    public UnityEvent OnLongDrag;

    public float longDragThreshold = 300f; // Adjust as needed for your long drag threshold

    private Vector2 dragStartPosition, previousDragPosition;
    private float timeDuration;
    private bool isUp;
    private float elapses;

    public void OnBeginDrag(PointerEventData eventData)
    {
        dragStartPosition = eventData.position;
        previousDragPosition = dragStartPosition;

        timeDuration = Time.time;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Calculate the distance dragged
        float dragDistance = (eventData.position - dragStartPosition).magnitude;


        Vector2 currentDragPosition = eventData.position;
        Vector2 dragDirection = currentDragPosition - previousDragPosition;


        // Check if the drag is moving up or down
        if (dragDirection.y > 0)
        {

            isUp = false;
            // Handle drag up logic here
        }
        else if (dragDirection.y < 0)
        {
            isUp = true;
            // Handle drag down logic here
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        Debug.Log("running");
        elapses = Time.time - timeDuration;

        if (isUp && elapses > 0.2f)
        {
            Debug.Log("running inside");
            OnLongDrag.Invoke();
        }
        // Reset dragStartPosition or perform other end drag actions if needed
    }

    
}

