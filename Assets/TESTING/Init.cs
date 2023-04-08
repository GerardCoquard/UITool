using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Init();
        UIUtilities.Init();
        AudioManager.Init();
        InputManager.Init();
        LocalizationManager.Init();
    }
}
