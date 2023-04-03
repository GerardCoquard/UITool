using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPT_CameraShake : MonoBehaviour,IOption
{
    public Toggle toggle;
    public OptionType optionType = OptionType.Settings;
    OptionType IOption.type => optionType;
    public string description = "Turn this off if screen-shake effects don't sit well or if you don't like them";
    OPT_Description _description;


    private void Start() {
        SelectableHandler selectable = toggle.GetComponent<SelectableHandler>();
        _description = FindObjectOfType<OPT_Description>();
        toggle.SetIsOnWithoutNotify(OptionsManager.cameraShake);
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        toggle.onValueChanged.AddListener(OnChange);
    }

    void OnChange(bool isOn)
    {
        OptionsManager.cameraShake = isOn;
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
        OptionsManager.cameraShake = OptionsManager.defaultData.cameraShake;
        toggle.SetIsOnWithoutNotify(OptionsManager.cameraShake);
    }
}
