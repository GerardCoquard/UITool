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
    private void Start() {
        SelectableHandler selectable = toggle.GetComponent<SelectableHandler>();
        toggle.SetIsOnWithoutNotify(OptionsManager.vSync);
        _description = FindObjectOfType<OPT_Description>();
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        toggle.onValueChanged.AddListener(OnChange);
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
        OptionsManager.vSync = OptionsManager.defaultData.vSync;
        toggle.SetIsOnWithoutNotify(OptionsManager.vSync);
    }
}
