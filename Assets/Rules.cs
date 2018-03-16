using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rules : MonoBehaviour
{
    public Button ButtonWin;
    public Canvas ScoreCanvas;
    public Canvas VictoryCanvas;
    public Canvas MainMenuCanvas;
    public Text ScoreText;

    public GameObject DroneGroup;

    public static int goal;
    public static int score;
    bool cycle;

    //считаем кол-во объектов с тэгом чекпоинт и проверяем, пролетел ли квадрокоптер через все из них
    void Start()
    {
        VictoryCanvas.enabled = false;
        cycle = true;
        goal = 1;
        score = 0;

        goal = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        ButtonWin.onClick.AddListener(WinClick);
    }

    void Update()
    {
        ScoreText.text = "Score: " + score + "/" + goal;
        if (cycle)
        {
            CheckWinCondition();
        }
    }

    void WinClick()
    {
        VictoryCanvas.enabled = false;
        DroneGroup.SetActive(false);
        MainMenuCanvas.enabled = true;
    }

    public void CheckWinCondition()
    {
        if (score == goal)
        {
            cycle = false;
            VictoryCanvas.enabled = true;            
        }
    }
}