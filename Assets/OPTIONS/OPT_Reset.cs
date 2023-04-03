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
    private void Start() {
        SelectableHandler selectable = button.GetComponent<SelectableHandler>();
        options = new List<IOption>(GetComponents<IOption>());
        _description = FindObjectOfType<OPT_Description>();
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        button.onClick.AddListener(OnChange);
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
        _description.Clear(description);
    }
}
