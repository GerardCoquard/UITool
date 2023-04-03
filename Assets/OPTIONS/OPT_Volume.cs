using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OPT_Volume : MonoBehaviour,IOption

{
    public AudioMixerGroup outputGroup;
    public AudioClip soundExample;
    public Slider slider;
    public AudioSource audioSource;
    public OptionType optionType = OptionType.Audio;
    OptionType IOption.type => optionType;
    public string description = "Changes the volume of ";
    OPT_Description _description;
    private void Start() {
        audioSource.clip = soundExample;
        audioSource.outputAudioMixerGroup = outputGroup;
        slider.value = AudioManager.GetVolume(outputGroup.name);
        _description = FindObjectOfType<OPT_Description>();
        SelectableHandler selectable = slider.GetComponent<SelectableHandler>();
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        selectable.onUnhighlight.AddListener(StopSound);
        slider.onValueChanged.AddListener(OnChange);
    }
    public void OnChange(float volume)
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
    void SetDescription()
    {
        _description.Set(description);
    }
    void ClearDescription()
    {
        _description.Clear(description);
    }
    public void Reset()
    {
        AudioManager.SetVolume(outputGroup.name,AudioManager.GetDefaultVolume(outputGroup.name));
        slider.value = AudioManager.GetVolume(outputGroup.name);
        StopSound();
    }
}
