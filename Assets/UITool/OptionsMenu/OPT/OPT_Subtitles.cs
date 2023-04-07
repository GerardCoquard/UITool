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
    private void Start() {
        SelectableHandler selectable = toggle.GetComponent<SelectableHandler>();
        toggle.SetIsOnWithoutNotify(OptionsManager.subtitles);
        _description = FindObjectOfType<OPT_Description>();
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        toggle.onValueChanged.AddListener(OnChange);
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
        OptionsManager.subtitles = OptionsManager.defaultData.subtitles;
        toggle.SetIsOnWithoutNotify(OptionsManager.subtitles);
    }
}
