using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPT_CursorLock : MonoBehaviour,IOption
{
    public Toggle toggle;
    public OptionType optionType = OptionType.Settings;
    OptionType IOption.type => optionType;
    public string description = "There's no escape! (for your mouse cursor from this window during gameplay)";
    OPT_Description _description;
    private void Start() {
        SelectableHandler selectable = toggle.GetComponent<SelectableHandler>();
        toggle.SetIsOnWithoutNotify(OptionsManager.cursorLock);
        _description = FindObjectOfType<OPT_Description>();
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        toggle.onValueChanged.AddListener(OnChange);
    }

    void OnChange(bool isOn)
    {
        OptionsManager.cursorLock = isOn;
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
        OptionsManager.cursorLock = OptionsManager.defaultData.cursorLock;
        toggle.SetIsOnWithoutNotify(OptionsManager.cursorLock);
    }
}
