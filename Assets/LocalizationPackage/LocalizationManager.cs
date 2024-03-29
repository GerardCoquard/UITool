using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class LocalizationManager 
{
    static List<string> languages;
    static Dictionary<string,List<string>> languagesDictionary = new Dictionary<string, List<string>>();
    static int currentLanguage;
    public static Action onLanguageChange;
    static string idKey;

    static LocalizationManager()
    {
        currentLanguage = DataManager.Load<int>("language");
        idKey = "ID_";
        LoadLanguages();
        LoadDictionary();
        ChangeLanguage(currentLanguage);
        DataManager.onSave += SaveData;
    }
    public static string GetLocalizedValue(string id)
    {
        string text = "Text Not Found";
        if(!languagesDictionary.ContainsKey(idKey+id)) return text;
        return languagesDictionary[idKey+id][currentLanguage];
    }
    public static List<string> GetLanguages()
    {
        return languages;
    }
    public static int GetCurrentLanguage()
    {
        return currentLanguage;
    }
    public static void ChangeLanguage(int language)
    {
        currentLanguage = language;
        onLanguageChange?.Invoke();
    }
    static void LoadLanguages()
    {
        var cvsFile = Resources.Load<TextAsset>("Localization");
        string[] lines = cvsFile.text.Split("\n"[0]);
        languages = new List<string>(lines[0].Split(';'));
        languages.RemoveAt(0);
    }
    static void LoadDictionary()
    {
        var cvsFile = Resources.Load<TextAsset>("Localization");
        string[] lines = cvsFile.text.Split("\n"[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(';');
            if(row.Length > 1)
            {
                List<string> words = new List<string>(row);
                words.RemoveAt(0);
                languagesDictionary.Add(row[0],words);
            }
        }
    }
    static void SaveData()
    {
        DataManager.Save("language",currentLanguage);
    }
    public static void Init(){}
}
