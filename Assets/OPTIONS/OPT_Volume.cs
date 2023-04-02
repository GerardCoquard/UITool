using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OPT_Volume : MonoBehaviour
{
    public AudioMixerGroup outputGroup;
    public AudioClip soundExample;
    public Slider slider;
    public AudioSource audioSource;
    private void Start() {
        audioSource.clip = soundExample;
        audioSource.outputAudioMixerGroup = outputGroup;
        slider.onValueChanged.AddListener(SetVolume);
        slider.GetComponent<SelectableHandler>().onUnhighlight.AddListener(StopSound);
        slider.value = AudioManager.GetVolume(outputGroup.name);
    }
    public void SetVolume(float volume)
    {
        AudioManager.SetVolume(outputGroup.name,volume);
        PlaySound();
    }
    public void PlaySound()
    {
        if(!audioSource.isPlaying && audioSource.gameObject.activeInHierarchy)
        {
            audioSource.Play();
        }
    }
    public void StopSound()
    {
        audioSource.Stop();
    }
}
