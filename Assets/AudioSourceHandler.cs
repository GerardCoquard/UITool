using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSourceHandler : MonoBehaviour
{
    AudioSource audioSource;
    private void OnEnable() {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        if(!audioSource.isPlaying && Time.timeScale != 0)
        {
            Destroy(gameObject);
        }
    }
    public AudioSourceHandler At(Vector3 pos)
    {
        gameObject.transform.position = pos;
        return this;
    }
    public AudioSourceHandler Volume(float vol)
    {
        audioSource.volume = vol;
        return this;
    }
    public AudioSourceHandler Pitch(float pitch)
    {
        audioSource.pitch = pitch;
        return this;
    }
    public AudioSourceHandler RandomPitch(float minPitch, float maxPitch)
    {
        float pitch = Random.Range(minPitch,maxPitch);
        audioSource.pitch = pitch;
        return this;
    }
    public void SetClip(AudioClip _clip)
    {
        audioSource.clip = _clip;
    }
    public void SetGroup(AudioMixerGroup _group)
    {
        audioSource.outputAudioMixerGroup = _group;
    }
    public void Play()
    {
        audioSource.Play();
    }
    IEnumerator Delete(AudioSource audioSource)
    {
        while(audioSource.isPlaying || Time.timeScale == 0)
        {
            yield return null;
        }
        Destroy(audioSource.gameObject);
    }
}
