using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    void Awake()
    {
        UIUtilities.Init();
        AudioManager.Init();
        InputManager.Init();
    }
    private void Update() {
        //Debug.Log(InputManager.playerInput.currentActionMap.name);
    }
}
