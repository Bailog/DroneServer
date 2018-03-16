using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button ButtonNewGame;
    public Button ButtonOptions;
    public Button ButtonExit;

    public Canvas Menu;
    public Canvas GameProperties;
    public Canvas Options;

    public GameObject DroneGroup;
    
	void Start ()
    {
        DroneGroup.SetActive(false);

        ButtonNewGame.onClick.AddListener(NewGameClick);
        ButtonOptions.onClick.AddListener(OptionsClick);
        ButtonExit.onClick.AddListener(ExitClick);

        Options.enabled = false;
        GameProperties.enabled = false;
    }

    public void NewGameClick()
    {
        Menu.enabled = false;
        GameProperties.enabled = true;
    }

    public void OptionsClick()
    {
        Menu.enabled = false;
        Options.enabled = true;
    }

    public void ExitClick()
    {
        Application.Quit();
    }
}
