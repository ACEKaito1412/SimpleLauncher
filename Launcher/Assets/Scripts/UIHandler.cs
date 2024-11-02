using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject AppUI;
    public GameObject GameUI;


    void Start()
    {
        AppUI.SetActive(false);
        GameUI.SetActive(true);
    }

    public void MainMenuPressed()
    {
        GameUI.SetActive(false);
        AppUI.SetActive(true);
    }

    public void SwitchCanvas()
    {
        AppUI.SetActive(false);
        GameUI.SetActive(true);
    }
}
