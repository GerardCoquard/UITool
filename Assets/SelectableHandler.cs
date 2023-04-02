using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class SelectableHandler : MonoBehaviour,ISelectHandler,IPointerEnterHandler,IPointerExitHandler,IDeselectHandler
{
    public bool clickSound = true;
    public string highlightSoundName = "ButtonHighlightSound";
    public string clickSoundName = "ButtonClickSound";
    public bool unselectOnClick = false;
    public UnityEvent onClick;
    public UnityEvent onHighlight;
    public UnityEvent onUnhighlight;
    [NonSerialized] public bool interactable = true;
    private void Start() {
        switch(GetComponent<Selectable>())
        {
            case Button button:
            button.onClick.AddListener(Click);
            break;
            case Toggle toggle:
            toggle.onValueChanged.AddListener(Click);
            break;
            case TMP_Dropdown dropdown:
            dropdown.onValueChanged.AddListener(Click);
            break;
            case Dropdown dropdown:
            dropdown.onValueChanged.AddListener(Click);
            break;
            default:
            break;
        }
    }
    public void OnSelect(BaseEventData eventData)
    {
        if(InputManager.device == Devices.Gamepad) Hihghlight();
    }
    public void OnDeselect(BaseEventData eventData)
    {
        if(InputManager.device == Devices.Gamepad) Unhighlight();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(InputManager.device == Devices.Keyboard) Hihghlight();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if(InputManager.device == Devices.Keyboard) Unhighlight();
    }
    void Hihghlight()
    {
        //playear sonido de highlight a traves de AudioManager
        onHighlight?.Invoke();
    }
    void Unhighlight()
    {
        onUnhighlight?.Invoke();
    }
    void Click()
    {
        if(!interactable) return;
        if(clickSound) ;//playear sonido de click a traves de AudioManager
        Menu parentMenu = GetComponentInParent<Menu>();
        if(parentMenu!=null) parentMenu.lastButton = gameObject;
        if(InputManager.device == Devices.Keyboard && unselectOnClick) EventSystem.current.SetSelectedGameObject(null);
        onClick?.Invoke();
    }
    void Click(bool toggleValue)
    {
        if(!interactable) return;
        if(clickSound) ;//playear sonido de click a traves de AudioManager
        Menu parentMenu = GetComponentInParent<Menu>();
        if(parentMenu!=null) parentMenu.lastButton = gameObject;
        if(InputManager.device == Devices.Keyboard && unselectOnClick) EventSystem.current.SetSelectedGameObject(null);
        onClick?.Invoke();
    }
    void Click(int dropdownValue)
    {
        if(!interactable) return;
        if(clickSound) ;//playear sonido de click a traves de AudioManager
        Menu parentMenu = GetComponentInParent<Menu>();
        if(parentMenu!=null) parentMenu.lastButton = gameObject;
        if(InputManager.device == Devices.Keyboard && unselectOnClick) EventSystem.current.SetSelectedGameObject(null);
        onClick?.Invoke();
    }
}
