using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioManager
{
    static AudioMixer audioMixer;
    static AudioData data;
    static AudioManager()
    {
        audioMixer = Resources.Load<AudioMixer>("AudioMixer");
        data = Resources.Load<AudioData>("AudioData");
    }
    public static float GetVolume(string volName)
    {
        if(!data.Exists(volName))
        {
            Debug.LogWarning("'" + volName + "' does not exist in the audio data. You probably need to create that volume in the audio data");
            return 0;
        }
        
        return PlayerPrefs.GetFloat(volName,data.GetDefaultVolume(volName));
    }
    public static void SetVolume(string volName,  float volume)
    {
        volume = Mathf.Clamp(volume,0f,1f);
        if(!data.Exists(volName))
        {
            Debug.LogWarning("'" + volName + "' does not exist in the audio data. You probably need to create that volume in the audio data");
            return;
        }

        float innerVol = Mathf.Log10(volume)*data.multiplier;
        audioMixer.SetFloat(volName, innerVol);
        PlayerPrefs.SetFloat(volName,volume);
    }
}
