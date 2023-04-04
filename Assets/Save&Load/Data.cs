using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data : DynamicData
{
    //AUDIO
    public float volumeMaster;
    public float volumeMusic;
    public float volumeSFX;
    public float volumeVoice;
    public float defaultVolumeMaster;
    public float defaultVolumeMusic;
    public float defaultVolumeSFX;
    public float defaultVolumeVoice;
    //OPTIONS
    public bool cameraShake;
    public bool cursorLock;
    public bool fullScreen;
    public bool subtitles;
    public bool vSync;
    public int resolution;
    public int defaultResolution;

    public Data()
    {
        OptionsDefaultConfig defaultOptions =  Resources.Load<OptionsDefaultConfig>("OptionsDefaultConfig");
        volumeMaster = defaultOptions.volumeMaster;
        volumeMusic = defaultOptions.volumeMusic;
        volumeSFX = defaultOptions.volumeSFX;
        volumeVoice = defaultOptions.volumeVoice;
        defaultVolumeMaster = defaultOptions.volumeMaster;
        defaultVolumeMusic = defaultOptions.volumeMusic;
        defaultVolumeSFX = defaultOptions.volumeSFX;
        defaultVolumeVoice = defaultOptions.volumeVoice;
        cameraShake = defaultOptions.cameraShake;
        cursorLock = defaultOptions.cursorLock;
        fullScreen = defaultOptions.fullScreen;
        subtitles = defaultOptions.subtitles;
        vSync = defaultOptions.vSync;
        resolution = defaultOptions.resolution;
        defaultResolution = defaultOptions.resolution;
    }
}

