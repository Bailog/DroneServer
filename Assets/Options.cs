using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour {

    public Button OK;
    public Button Cancel;
    public Slider Volume;

    public Canvas MainMenu;
    public Canvas OptionsMenu;

    //привязка функций нажатия на кнопки 
    void Start ()
    {
        OK.onClick.AddListener(OKClick);
        Cancel.onClick.AddListener(CancelClick);
    }
	
    //принять все изменения в настройках и вернуться в меню
	void OKClick()
    {
        OptionsMenu.enabled = false;
        MainMenu.enabled = true;
    }

    //отменить все изменения в настройках и вернуться в меню
    void CancelClick()
    {
        OptionsMenu.enabled = false;
        MainMenu.enabled = true;
    }
}
