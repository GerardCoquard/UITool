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
    SelectableHandler selectable;
    private void Start() {
        toggle.isOn = OptionsManager.cursorLock;
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
        bool sound = selectable.clickSound;
        selectable.clickSound = false;
        OptionsManager.cursorLock = OptionsManager.defaultData.cursorLock;
        toggle.isOn = OptionsManager.cursorLock;
        selectable.clickSound = sound;
    }
}
