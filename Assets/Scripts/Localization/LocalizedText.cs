using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class LocalizedText : MonoBehaviour
{
    [SerializeField]
    private string _key;

    private LocalizationManager _localizationManager;
    private TMP_Text _text;
    
    public string Key => _key;

    private void Awake()
    { 
        _text = GetComponent<TMP_Text>();
        _localizationManager = FindObjectOfType<LocalizationManager>();
    }

    private void OnEnable()
    {
        _localizationManager.LanguageChanged += SetText;
    }

    private void OnDisable()
    {
        _localizationManager.LanguageChanged -= SetText;
    }

    private void Start()
    {
        SetText();
    }

    private void SetText()
    {
        _text.text = _localizationManager.GetLocalizedValue(_key);
    }
}