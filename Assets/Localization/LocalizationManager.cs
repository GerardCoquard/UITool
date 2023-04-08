using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class LocalizationManager 
{

    private static Dictionary<string, string> localizedText;
    public static Action OnLanguageChange;

    static LocalizationManager()
    {
        ChangeLanguage(Languages.English);
    }

    public static void LoadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName + ".json");
        if (File.Exists(filePath))
        {
            try
            {
                string dataAsJson = File.ReadAllText(filePath);


                LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);
                for (int i = 0; i < loadedData.items.Count; i++)
                {
                    localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
                }
            }
            catch(Exception e)
            {
                Debug.LogWarning("Error occured: " + e);
            }
            OnLanguageChange?.Invoke();
        }
        else
        {
            Debug.LogError("Cannot find file!");
        }
    }

    public static void ChangeLanguage(Languages language)
    {
        switch (language)
        {
            case Languages.English:
                LoadLocalizedText("en");
                break;
            case Languages.Español:
                LoadLocalizedText("es");
                break;
            case Languages.Català:
                LoadLocalizedText("cat");
                break;
            default:
                break;
        }
    }
    public static string GetLocalizedValue(string key)
    {
        string result = "Localized text not found";
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }
        return result;
    }
    public static void Init(){}
}

[System.Serializable]
public class LocalizationData
{
    public List<LocalizationItem> items = new List<LocalizationItem>();
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}

public enum Languages{
    English,
    Español,
    Català

}
