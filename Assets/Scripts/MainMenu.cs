using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject menu;
    public UIButton[] screens;
    private static MainMenu instance;
    private int panelIndex;
    public int PanelIndex
    { 
        get { return panelIndex; } 
        set { panelIndex = value; }
    }

    //private void Awake()
    //{
    //    foreach (var x in screens)
    //        x.przycisk.onClick.AddListener(Proceed);
    //}

    private MainMenu()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else instance = this;
    }

    public static MainMenu Instance
    {
        get { return instance; }
    }

    //private void Awake()
    //{
    //    foreach(var x in screens)
    //    Debug.Log(x.przycisk.onClick.GetPersistentEventCount());

    //}


    // Start is called before the first frame update



    // Update is called once per frame

    public void Proceed()
    {
        menu.SetActive(false);
        screens[panelIndex].gameObject.SetActive(true);
    }

    public void Back()
    {
        screens[panelIndex].gameObject.SetActive(false);
        menu.SetActive(true);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
