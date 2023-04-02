using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioData", menuName = "AudioData", order = 1)]
public class AudioData : ScriptableObject
{
    public float multiplier = 30f;
    [SerializeField]
    public List<Volume> volumes;
    public float GetDefaultVolume(string volName)
    {
        foreach (Volume vol in volumes)
        {
            if(vol._name == volName) return vol.defaultVolume;
        }
        return 0;
    }
    public bool Exists(string volName)
    {
        foreach (Volume vol in volumes)
        {
            if(vol._name == volName) return true;
        }
        return false;
    }
}
