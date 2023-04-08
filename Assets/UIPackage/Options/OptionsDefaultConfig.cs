using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsDefaultConfig", menuName = "OptionsDefaultConfig", order = 1)]
public class OptionsDefaultConfig : ScriptableObject
{
    //AUDIO
    [Range(0f,1f)]
    public float volumeMaster = 0.5f;
    [Range(0f,1f)]
    public float volumeMusic = 1f;
    [Range(0f,1f)]
    public float volumeSFX = 1f;
    [Range(0f,1f)]
    public float volumeVoice = 1f;
    //OPTIONS
    public bool cameraShake = true;
    public bool cursorLock = true;
    public bool fullScreen = true;
    public bool subtitles = true;
    public bool vSync = true;
    public int resolution = -1;
    public Languages language = Languages.English;
}
