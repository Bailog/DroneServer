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

    public static int goal; // переменная для подсчета общего числа чекпоинтов
    public static int score; // переменная для подсчета кол-ва пройденных чекпоинтов
    //переменная для проверки на условие выполнения трассы
    bool cycle;

    //считаем кол-во объектов с тэгом чекпоинт
    void Start()
    {
        VictoryCanvas.enabled = false;
        
        cycle = true;
        goal = 1;
        score = 0;

        goal = GameObject.FindGameObjectsWithTag("Checkpoint").Length;
        ButtonWin.onClick.AddListener(WinClick);
    }

    //обновляем количество пройденных чекпоинтов
    void Update()
    {
        ScoreText.text = "Score: " + score + "/" + goal;
        if (cycle)
        {
            CheckWinCondition();
        }
    }

    //проверяем, пролетел ли квадрокоптер через все чекпоинты, 
    //если да, отображаем окно с поздравлением
    public void CheckWinCondition()
    {
        if (score == goal)
        {
            cycle = false;
            VictoryCanvas.enabled = true;            
        }
    }

    //при нажатии на кнопку возращаемся в главное меню
    void WinClick()
    {
        VictoryCanvas.enabled = false;
        DroneGroup.SetActive(false);
        MainMenuCanvas.enabled = true;
    }
}