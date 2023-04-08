using UnityEngine;
using TMPro;

public class Localization : MonoBehaviour
{
    public string reference;
    TextMeshProUGUI text;
    private void OnEnable()
    {
        if (text==null) text = GetComponent<TextMeshProUGUI>();
        LocalizationManager.OnLanguageChange += UpdateTextLanguage;
    }

    private void OnDisable()
    {
        LocalizationManager.OnLanguageChange -= UpdateTextLanguage;
    }  

    void UpdateTextLanguage()
    {
        text.text = LocalizationManager.GetLocalizedValue(reference);
    }

}


