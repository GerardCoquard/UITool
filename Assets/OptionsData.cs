using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsData", menuName = "OptionsData", order = 1)]
public class OptionsData : ScriptableObject
{
    string fullScreen;
    string resolutions;
    string cameraShake;
    string subtitles;
    string cursorLock;
    string vSync;
}
