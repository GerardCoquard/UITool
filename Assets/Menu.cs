using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Menu : MonoBehaviour
{
    public GameObject firstButton;
    public bool rememberLastButton = true;
    public bool cursorLockRestricted = false;
    public bool pauseTime = true;
    [NonSerialized] public GameObject lastButton;
    public void OnEnable()
    {
        if(InputManager.device == Devices.Gamepad) UIUtilities.HighlightButton(lastButton==null || !rememberLastButton? firstButton : lastButton);
    }
}
