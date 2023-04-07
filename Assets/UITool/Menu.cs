using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    public GameObject firstButton;
    public bool rememberLastButton = true;
    public bool cursorLockRestricted = false;
    public bool pauseTime = true;
    public bool closeOnBack = true;
    bool initialized = false;
    [NonSerialized] public GameObject lastButton;
    public virtual void OnStart(){initialized = true;}
    public virtual void OnEnable()
    {
        if(!initialized) OnStart();
        if(InputManager.device == Devices.Gamepad) UIUtilities.HighlightButton(lastButton==null || !rememberLastButton? firstButton : lastButton);
        SubscribeOnBack();
    }
    public virtual void OnDisable() {
        UnsubscribeOnBack();
    }
    public virtual void Close(InputAction.CallbackContext context)
    {
        if(context.started) gameObject.SetActive(false);
    }

    public void SubscribeOnBack()
    {
        if(closeOnBack) InputManager.GetAction("Back").action += Close;
    }
    public void UnsubscribeOnBack()
    {
        if(closeOnBack) InputManager.GetAction("Back").action -= Close;
    }
}
