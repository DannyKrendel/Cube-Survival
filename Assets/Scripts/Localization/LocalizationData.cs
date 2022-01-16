using System;
using UnityEngine;

[Serializable]
public struct LocalizationData
{
    public string languageName;
    public LocalizationDataItem[] items;
}

[Serializable]
public struct LocalizationDataItem
{
    public string key;
    [TextArea] public string value;
}