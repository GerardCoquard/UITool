using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OPT_Resolution : MonoBehaviour,IOption
{
    public TMP_Dropdown dropdown;
    Resolution[] resolutions;
    int initialChildrens;
    int lastFrameChildrens;
    public OptionType optionType = OptionType.Graphics;
    OptionType IOption.type => optionType;
    public string description = "Sets the resolution of the game window";
    OPT_Description _description;
    SelectableHandler selectable;
    private void Start() {
        SetResolutions();
        initialChildrens = dropdown.GetComponentsInChildren<RectTransform>().Length;
        lastFrameChildrens = initialChildrens;
        _description = FindObjectOfType<OPT_Description>();
        selectable = dropdown.GetComponent<SelectableHandler>();
        bool sound = selectable.clickSound;
        selectable.clickSound = false;
        selectable.onHighlight.AddListener(SetDescription);
        selectable.onUnhighlight.AddListener(ClearDescription);
        dropdown.onValueChanged.AddListener(OnChange);
        selectable.clickSound = sound;
    }

    void OnChange(int res)
    {
        OptionsManager.resolution = res;
        Resolution resolution = resolutions[res];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    void SetResolutions()
    {
        resolutions = GetResolutions().ToArray();

        dropdown.ClearOptions();


        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " X " + resolutions[i].height + " @ " + resolutions[i].refreshRate + "HZ";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropdown.AddOptions(options);
        if(OptionsManager.defaultResolution == OptionsManager.defaultData.resolution)
        {
            OptionsManager.defaultResolution = currentResolutionIndex;
            OptionsManager.resolution = currentResolutionIndex;
        }
        dropdown.value = OptionsManager.resolution;
        dropdown.RefreshShownValue();
    }
    List<Resolution> GetResolutions()
    {
        //Filters out all resolutions with low refresh rate:
        Resolution[] resolutions = Screen.resolutions;
        HashSet<System.ValueTuple<int, int>> uniqResolutions = new HashSet<System.ValueTuple<int, int>>();
        Dictionary<System.ValueTuple<int, int>, int> maxRefreshRates = new Dictionary<System.ValueTuple<int, int>, int>();
        for (int i = 0; i < resolutions.GetLength(0); i++)
        {
            //Add resolutions (if they are not already contained)
            System.ValueTuple<int, int> resolution = new System.ValueTuple<int, int>(resolutions[i].width, resolutions[i].height);
            uniqResolutions.Add(resolution);
            //Get highest framerate:
            if (!maxRefreshRates.ContainsKey(resolution))
            {
                maxRefreshRates.Add(resolution, resolutions[i].refreshRate);
            }
            else
            {
                maxRefreshRates[resolution] = resolutions[i].refreshRate;
            }
        }
        //Build resolution list:
        List<Resolution> uniqResolutionsList = new List<Resolution>(uniqResolutions.Count);
        foreach (System.ValueTuple<int, int> resolution in uniqResolutions)
        {
            Resolution newResolution = new Resolution();
            newResolution.width = resolution.Item1;
            newResolution.height = resolution.Item2;
            if (maxRefreshRates.TryGetValue(resolution, out int refreshRate))
            {
                newResolution.refreshRate = refreshRate;
            }
            uniqResolutionsList.Add(newResolution);
        }
        return uniqResolutionsList;
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
        OptionsManager.resolution = OptionsManager.defaultResolution;
        Resolution resolution = resolutions[OptionsManager.resolution];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        selectable.clickSound = sound;
    }
}
