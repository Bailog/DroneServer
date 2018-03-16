using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePropertiesUI : MonoBehaviour {

    public Button OK;
    public Button Cancel;
    public Dropdown Mode;
    public Dropdown QuadModel;
    public Dropdown Track;

    public Canvas MainMenu;
    public Canvas GameProperties;

    public GameObject DroneGroup;

    // привязывает функции нажатия на кнопки
    void Start ()
    {
        OK.onClick.AddListener(OKClick);
        Cancel.onClick.AddListener(CancelClick);
    }
	
    //отключает меню и включает элементы квадрокоптера (TrackGroup)
    void OKClick()
    {
        GameProperties.enabled = false;
        DroneGroup.SetActive(true);
    }

    //возвращение в главное меню
    void CancelClick()
    {
        GameProperties.enabled = false;
        MainMenu.enabled = true;
    }
}