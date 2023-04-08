using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChangeTest : MonoBehaviour
{
    public string otherScene;
    private void OnEnable() {
        InputManager.GetAction("Test").action += ChangeScene;
    }
    private void OnDisable() {
        InputManager.GetAction("Test").action -= ChangeScene;
    }
    void ChangeScene(InputAction.CallbackContext context)
    {
        if(context.ReadValueAsButton()) SceneManager.LoadScene(otherScene);
    }
}
