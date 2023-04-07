using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OPT_VolumeMaster : MonoBehaviour,IOption
{
    public AudioMixerGroup outputGroup;
    public Slider slider;
    List<OPT_Volume> otherVolumes;
    public OptionType optionType = OptionType.Audio;
    OptionType IOption.type => optionType;
    public string description = "Changes the master volume of the game";
    OPT_Description _description;
    private void Start() {
        otherVolumes = new List<OPT_Volume>(GetComponents<OPT_Volume>());
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

        foreach (OPT_Volume vol in otherVolumes)
        {
            vol.PlaySound();   
        }
    }
    public void StopSound()
    {
        foreach (OPT_Volume vol in otherVolumes)
        {
            vol.StopSound();
        }
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
