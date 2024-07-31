using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongPressClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float longPressDuration = 0.7f; // Duration in seconds to trigger a long press
    private bool isPointerDown = false;
    private float pointerDownTimer = 0;

    public event Action OnLongPress; // Custom event for long press
    public bool longPressTriggered = false;

    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError("LongPressButton requires a Button component");
        }
    }

    private void Update()
    {
        if (isPointerDown)
        {
            pointerDownTimer += Time.deltaTime;

            if (pointerDownTimer >= longPressDuration)
            {
                isPointerDown = false;
                longPressTriggered = true;
                OnLongPress?.Invoke();
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPointerDown = true;
        pointerDownTimer = 0;
        longPressTriggered = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPointerDown = false;
        pointerDownTimer = 0;
    }
}
