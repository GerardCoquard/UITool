using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OPT_Reset : MonoBehaviour
{
    public OptionType optionType;
    public Button button;
    List<IOption> options;
    public string description = "Resets all the * settings to its default";
    OPT_Description _description;
    SelectableHandler selectable;
    private void Start() {
        options = new List<IOption>(GetComponents<IOption>());
        _description = FindObjectOfType<OPT_Description>();
        selectable = button.GetComponent<SelectableHandler>();
        bool sound = selectable.clickSound;
        selectable.clickSound = false;
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        button.onClick.AddListener(OnChange);
        selectable.clickSound = sound;
    }
    void OnChange()
    {
        foreach (IOption opt in options)
        {
            if(opt.type == optionType) opt.Reset();
        }
    }
    void SetDescription()
    {
        _description.Set(description);
    }
    void ClearDescription()
    {
        bool sound = selectable.clickSound;
        selectable.clickSound = false;
        _description.Clear(description);
        selectable.clickSound = sound;
    }
}
