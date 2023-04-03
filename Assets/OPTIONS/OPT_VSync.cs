using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPT_VSync : MonoBehaviour,IOption
{
    public Toggle toggle;
    public OptionType optionType = OptionType.Graphics;
    OptionType IOption.type => optionType;
    public string description = "Sets frame rate to screen refresh rate. If things look fine, let it on";
    OPT_Description _description;
    SelectableHandler selectable;
    private void Start() {
        toggle.isOn = OptionsManager.vSync;
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
        OptionsManager.vSync = isOn;
        QualitySettings.vSyncCount = isOn?1:0;
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
        OptionsManager.vSync = OptionsManager.defaultData.vSync;
        toggle.isOn = OptionsManager.vSync;
        selectable.clickSound = sound;
    }
}
