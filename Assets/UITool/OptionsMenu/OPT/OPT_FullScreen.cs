using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPT_FullScreen : MonoBehaviour,IOption
{
    public Toggle toggle;
    public OptionType optionType = OptionType.Graphics;
    OptionType IOption.type => optionType;
    public string description = "Full screen or windowed";
    OPT_Description _description;
    private void Start() {
        SelectableHandler selectable = toggle.GetComponent<SelectableHandler>();
        toggle.SetIsOnWithoutNotify(OptionsManager.fullScreen);
        _description = FindObjectOfType<OPT_Description>();
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        toggle.onValueChanged.AddListener(OnChange);
    }

    void OnChange(bool isOn)
    {
        OptionsManager.fullScreen = isOn;
        Screen.fullScreen = isOn;
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
        OptionsManager.fullScreen = OptionsManager.defaultData.fullScreen;
        toggle.SetIsOnWithoutNotify(OptionsManager.fullScreen);
    }
}
