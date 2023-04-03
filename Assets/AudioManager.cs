using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class AudioManager
{
    static AudioMixer audioMixer;
    static Dictionary<string,float> volumes;
    static Dictionary<string,float> defaultVolumes;
    static float multiplier;
    static GameObject audioPrefab;
    static AudioManager()
    {
        audioMixer = Resources.Load<AudioMixer>("AudioMixer");
        audioPrefab = Resources.Load<GameObject>("AudioPrefab");
        volumes = new Dictionary<string, float>();
        defaultVolumes = new Dictionary<string, float>();
        List<AudioMixerGroup> outputs = new List<AudioMixerGroup>(audioMixer.FindMatchingGroups(string.Empty));
        foreach (AudioMixerGroup group in outputs)
        {
            volumes.Add(group.name,DataManager.Load<float>("volume" + group.name));
            defaultVolumes.Add(group.name,DataManager.Load<float>("defaultVolume" + group.name));
            SetVolume(group.name,volumes[group.name]);
        }
        multiplier = 30f;
        DataManager.onSave += SaveData;
    }
    public static float GetVolume(string volName)
    {
        return volumes[volName];
    }
    public static void SetVolume(string volName,  float volume)
    {
        volume = Mathf.Clamp(volume,0f,1f);
        float innerVol = Mathf.Log10(volume)*multiplier;
        audioMixer.SetFloat(volName, innerVol);
        volumes[volName] = volume;
    }
    public static float GetDefaultVolume(string volName)
    {
        return defaultVolumes[volName];
    }
    static void SaveData()
    {
        foreach (var vol in volumes)
        {
            DataManager.Save("volume" + vol.Key,vol.Value);
        }
    }
    public static void Play(string clipName)
    {
        AudioSource audio = MonoBehaviour.Instantiate(audioPrefab).GetComponent<AudioSource>();
        audio.clip = Resources.Load<AudioClip>(clipName);
        audio.Play();
    }
    public static void Init(){}
}
