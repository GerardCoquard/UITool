using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonHandler : MonoBehaviour,ISelectHandler,IPointerEnterHandler,IPointerExitHandler,IDeselectHandler
{
    public UnityEvent onSelect;
    public void OnSelect(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }
    public void OnDeselect(BaseEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
