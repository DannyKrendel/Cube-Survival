using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Localization Data", menuName = "Localization Data")]
public class LanguageData : ScriptableObject
{
    public string languageName;
    public string fileName;
}