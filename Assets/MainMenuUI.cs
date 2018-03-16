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
    
    //привязывает функции нажатия на кнопки
	void Start ()
    {
        DroneGroup.SetActive(false);

        ButtonNewGame.onClick.AddListener(NewGameClick);
        ButtonOptions.onClick.AddListener(OptionsClick);
        ButtonExit.onClick.AddListener(ExitClick);

        Options.enabled = false;
        GameProperties.enabled = false;
    }

    //выключение главного меню и отображение предварительной настройки симуляции
    public void NewGameClick()
    {
        Menu.enabled = false;
        GameProperties.enabled = true;
    }

    //выключение главного меню и включение настроек
    public void OptionsClick()
    {
        Menu.enabled = false;
        Options.enabled = true;
    }

    //выход из приложения
    public void ExitClick()
    {
        Application.Quit();
    }
}
