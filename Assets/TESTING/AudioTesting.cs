using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioTesting : MonoBehaviour
{
    void Start()
    {
        AudioManager.Play("MusicSound");
    }
    private void OnEnable() {
        InputManager.GetAction("Click").action += Pause;
    }
    private void OnDisable() {
        InputManager.GetAction("Click").action -= Pause;
    }

    void Pause(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton())
        {
            if(Time.timeScale != 0f)
            {
                Time.timeScale = 0f;
                AudioManager.Pause();
            }
            else
            {
                Time.timeScale = 1f;
                AudioManager.Resume();
            }
        }
    }
}
