using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OPT_VolumeMaster : MonoBehaviour
{
    public AudioMixerGroup outputGroup;
    public Slider slider;
    List<OPT_Volume> otherVolumes;
    private void Start() {
        otherVolumes = new List<OPT_Volume>(GetComponents<OPT_Volume>());
        slider.onValueChanged.AddListener(SetVolume);
        slider.GetComponent<SelectableHandler>().onUnhighlight.AddListener(StopSound);
        slider.value = AudioManager.GetVolume(outputGroup.name);
    }
    public void SetVolume(float volume)
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
}
