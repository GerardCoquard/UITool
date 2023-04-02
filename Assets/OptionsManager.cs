using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class OptionsManager
{
    public static OptionsData data;
    static OptionsManager()
    {
        data = Resources.Load<OptionsData>("OptionsData");
    }
}
