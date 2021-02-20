using GameToolkit.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocaleChanged : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textLanguage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Localization.Instance.LocaleChanged += LanguageChangedWorked;
    }

    private void OnDisable()
    {
        Localization.Instance.LocaleChanged -= LanguageChangedWorked;
    }

    private void LanguageChangedWorked(object sender, LocaleChangedEventArgs a)
    {
        print(string.Format("Localization has changed from {0} to {1} language",a.PreviousLanguage,a.CurrentLanguage));
    }
    public void LanguageChanged()
    {
        SystemLanguage lang = SystemLanguage.English;

        switch(textLanguage.text)
        {
            case "English": lang = SystemLanguage.English; break;
            case "Polish": lang = SystemLanguage.Polish; break;
            case "German": lang = SystemLanguage.German; break;
            case "Chinese (simplified)": lang = SystemLanguage.ChineseSimplified; break;
            case "Russian": lang = SystemLanguage.Russian; break;
            case "Spanish": lang = SystemLanguage.Spanish; break;
            case "Japanese": lang = SystemLanguage.Japanese; break;

        }
        Localization.Instance.CurrentLanguage = lang;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
