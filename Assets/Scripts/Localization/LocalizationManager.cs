using System;
using System.IO;
using System.Linq;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private LanguageData _currentLanguage;

    public event Action LanguageChanged;

    private readonly IStorage<LocalizationData> _storage = new XmlStorage();
    private LocalizationData _localization;

    private void Awake()
    {
        UpdateLanguage();
    }

    private void UpdateLanguage()
    {
        var path = Path.Combine(Application.streamingAssetsPath, _currentLanguage.fileName);
        _localization = _storage.Get(path);

        LanguageChanged?.Invoke();

        Debug.Log("Localization loaded with " + _localization.items.Length + " entries");
    }

    public string GetLocalizedValue(string key)
    {
        return _localization.items.FirstOrDefault(item => item.key == key).value;
    }
}