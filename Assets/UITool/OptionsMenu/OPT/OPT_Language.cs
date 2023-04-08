using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OPT_Language : MonoBehaviour,IOption
{
    public TMP_Dropdown dropdown;
    bool lastFrameOpened = false;
    Languages [] languages;
    public OptionType optionType = OptionType.Settings;
    OptionType IOption.type => optionType;
    public string description = "Current language of all texts in the game";
    OPT_Description _description;
    public UnityEvent onOpen;
    public UnityEvent onClose;
    private void Start() {
        SelectableHandler selectable = dropdown.GetComponent<SelectableHandler>();
        SetLanguages();
        _description = FindObjectOfType<OPT_Description>();
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        dropdown.onValueChanged.AddListener(OnChange);
    }
    
    void OnChange(int _language)
    {
        OptionsManager.language = languages[_language];
        LocalizationManager.ChangeLanguage(languages[_language]);
    }
    private void Update() {
        bool openedThisFrame = dropdown.transform.childCount != 4;
        if(openedThisFrame && !lastFrameOpened)
        {
            InputManager.GetAction("Back").action += CloseDropdown;
            onOpen?.Invoke();
        }
        if(!openedThisFrame && lastFrameOpened)
        {
            InputManager.GetAction("Back").action -= CloseDropdown;
            onClose?.Invoke();
            if(InputManager.device == Devices.Keyboard) EventSystem.current.SetSelectedGameObject(null);
        }
        lastFrameOpened = openedThisFrame;
    }
    void CloseDropdown(InputAction.CallbackContext context)
    {
        if(context.started) dropdown.Hide();
    }
    void SetLanguages()
    {
        languages = (Languages[])System.Enum.GetValues(typeof(Languages));

        dropdown.ClearOptions();

        List<string> options = new List<string>();
        foreach (Languages _language in languages)
        {
            options.Add(_language.ToString());
        }
        dropdown.AddOptions(options);
        dropdown.SetValueWithoutNotify((int)OptionsManager.language);
        dropdown.RefreshShownValue();
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
        OptionsManager.language = OptionsManager.defaultData.language;
        dropdown.SetValueWithoutNotify((int)OptionsManager.language);
        dropdown.RefreshShownValue();
        LocalizationManager.ChangeLanguage(OptionsManager.language);
    }
}
