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
    static GameObject audioHolder;
    static Dictionary<string,Sound> clips = new Dictionary<string, Sound>();
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
        LoadAudio("Music");
        LoadAudio("SFX");
        LoadAudio("Voice");
        multiplier = 30f;
        audioHolder = CreateAudioHolder();
        DataManager.onSave += SaveData;
    }
    public static AudioSourceHandler Play(string clipName)
    {
        if(!clips.ContainsKey(clipName))
        {
            Debug.LogWarning("There's no AudioClip in Resources matching the name " + clipName);
            return null;
        }
        AudioSourceHandler audio = MonoBehaviour.Instantiate(audioPrefab,audioHolder.transform).GetComponent<AudioSourceHandler>();
        audio.SetClip(clips[clipName].sound);
        audio.SetGroup(clips[clipName].group);
        audio.Play();
        return audio;
    }
    static void LoadAudio(string groupName)
    {
        if(Resources.LoadAll<AudioClip>(groupName).Length <= 0) Debug.LogWarning("Wrong Resources audio loading folder name");
        AudioClip [] sounds = Resources.LoadAll<AudioClip>(groupName);
        foreach (AudioClip sound in sounds)
        {
            clips.Add(sound.name, new Sound(sound,audioMixer.FindMatchingGroups(groupName)[0]));
        }
    }
    public static void Pause()
    {
        AudioSource [] audios = audioHolder.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }
    }
    public static void Resume()
    {
        AudioSource [] audios = audioHolder.GetComponentsInChildren<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.UnPause();
        }
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
    static GameObject CreateAudioHolder()
    {
        GameObject holder = MonoBehaviour.Instantiate(new GameObject());
        holder.name = "AUDIO";
        MonoBehaviour.DontDestroyOnLoad(holder);
        return holder;
    }
    public static void Init(){}
}
