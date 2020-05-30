using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeOfGame : MonoBehaviour
{
    [HideInInspector]
    public bool isTwoPlayers;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void OnePlayer()
    {
        isTwoPlayers = false;
    }
    public void TwoPlayers()
    {
        isTwoPlayers = true;
    }
}
