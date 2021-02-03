using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // the scores of the players
    public int Player1Score;
    public int Player2Score;

    public OnScreenTimerController timerController;

    // the text values for the scores
    public Text TPlayer1Score;
    public Text TPlayer2Score;

    // values for the endscreen with the scores and winner text
    public Text endPlayer1Score;
    public Text endPlayer2Score;
    public Text winnerText;

    // The popscreens for the info
    public GameObject beginScreen;
    public GameObject endScreen;

    public float startTimer = 10f;
    public Text StartTimer;

    private float endTimer = 100f;

    public bool gameIsActive = false;

    private string WinnerName;

    void Start()
    {
        // start with a clean score
        PlayerPrefs.DeleteAll();

        // start the game timer
        beginScreen.SetActive(true);
        endScreen.SetActive(false);
    }

    void Update()
    {

        Player1Score = PlayerPrefs.GetInt("Player1Score");
        Player2Score = PlayerPrefs.GetInt("Player2Score");

        // set the score text 
        TPlayer1Score.text = Player1Score.ToString();
        TPlayer2Score.text = Player2Score.ToString();

        startTimer -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(startTimer);
        StartTimer.text = seconds.ToString();

        if (startTimer <= 0)
        {
            beginScreen.SetActive(false);
            timerController.BeginTimer();
            gameIsActive = true;
        }

        if (timerController.gameEnded == true)
        {
            gameIsActive = false;
            endScreen.SetActive(true);
            endPlayer1Score.text = Player1Score.ToString();
            endPlayer2Score.text = Player2Score.ToString();
            endTimer -= Time.deltaTime;
            if (Player1Score > Player2Score)
            {

                WinnerName = "SPELER 1";

            }
            else
            {
                WinnerName = "SPELER 2";
            }
            winnerText.text = "PROFICIAT " + WinnerName + "!";

            //logic OR operator
            if (endTimer <= 0 ^ Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(sceneName: "StartScene");
            }
        }
    }
}


    