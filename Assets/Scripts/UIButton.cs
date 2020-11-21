using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{

    public Button przycisk;
    //void Awake()
    //{
    //    przycisk.onClick.AddListener(SetIndex);
    //}

    public void SetIndex()
    {
        MainMenu.Instance.PanelIndex = Array.IndexOf(MainMenu.Instance.screens, this);
    }

}
