using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LongPressBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public UnityEvent OnLongClick;
    private bool _pointerDown;


    // Update is called once per frame
    void Update()
    {
        if(_pointerDown){
            OnLongClick.Invoke();
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        _pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData){
        _pointerDown = false;
    }

}
