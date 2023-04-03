using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPT_Subtitles : MonoBehaviour,IOption
{
    public Toggle toggle;
    public OptionType optionType = OptionType.Settings;
    OptionType IOption.type => optionType;
    public string description = "Display text captions during speech";
    OPT_Description _description;
    SelectableHandler selectable;
    private void Start() {
        toggle.isOn = OptionsManager.subtitles;
        _description = FindObjectOfType<OPT_Description>();
        selectable = toggle.GetComponent<SelectableHandler>();
        bool sound = selectable.clickSound;
        selectable.clickSound = false;
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        toggle.onValueChanged.AddListener(OnChange);
        selectable.clickSound = sound;
    }

    void OnChange(bool isOn)
    {
        OptionsManager.subtitles = isOn;
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
        bool sound = selectable.clickSound;
        selectable.clickSound = false;
        OptionsManager.subtitles = OptionsManager.defaultData.subtitles;
        toggle.isOn = OptionsManager.subtitles;
        selectable.clickSound = sound;
    }
}
