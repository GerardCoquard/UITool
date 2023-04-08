using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Description : MonoBehaviour
{
    TextMeshProUGUI label;
    private void Start() {
        label = GetComponent<TextMeshProUGUI>();
        label.text = "";
    }
    public void Set(string description)
    {
        label.text = description;
    }
    public void Clear()
    {
        label.text = "";
    }
}
