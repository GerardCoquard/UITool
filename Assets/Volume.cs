using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct Volume
{
    public string _name;
    [Range(0f,1f)]
    public float defaultVolume;
}
