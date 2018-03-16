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
	
	void Start ()
    {
        OK.onClick.AddListener(OKClick);
        Cancel.onClick.AddListener(CancelClick);
    }
	
	void OKClick()
    {
        OptionsMenu.enabled = false;
        MainMenu.enabled = true;
    }

    void CancelClick()
    {
        OptionsMenu.enabled = false;
        MainMenu.enabled = true;
    }
}
