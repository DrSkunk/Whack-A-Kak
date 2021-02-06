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

    //Get the position for the end score 
    public Image Player1Image;
    public Image Player2Image;

    //the sprites for the winner and loser
    public Sprite WonImage;
    public Sprite LostImage;

    public float startTimer = 10f;
    public Text StartTimer;

    private float endTimer = 100f;

    //public bool the see if the game is active
    public bool gameIsActive = false;

    private string WinnerName;

    //serialController to communicate with the arduino
    public SerialController serialController;

    void Start()
    {
        // start with a clean score
        PlayerPrefs.DeleteAll();

        // start the game timer
        beginScreen.SetActive(true);
        endScreen.SetActive(false);

        //find the serial controller
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    void Update()
    {
        //get the score to display when it changes
        Player1Score = PlayerPrefs.GetInt("Player1Score");
        Player2Score = PlayerPrefs.GetInt("Player2Score");

        // set the score text 
        TPlayer1Score.text = Player1Score.ToString();
        TPlayer2Score.text = Player2Score.ToString();

        //start the starttimer for the information and display it in seconds
        startTimer -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(startTimer);
        StartTimer.text = seconds.ToString();

        //if the starttimer runs out start the game
        if (startTimer <= 0)
        {
            beginScreen.SetActive(false);
            timerController.BeginTimer();
            gameIsActive = true;
        }

        //if the timer runs out show the end screen
        if (timerController.gameEnded == true)
        {
            //send command to arduino that leds need to be reset
            serialController.SendSerialMessage("X0");

            gameIsActive = false;
            endScreen.SetActive(true);
            endPlayer1Score.text = Player1Score.ToString() + "x";
            endPlayer2Score.text = Player2Score.ToString() + "x";
            endTimer -= Time.deltaTime;

            if (Player1Score > Player2Score)
            {

                WinnerName = "SPELER 1";
                Player1Image.sprite = WonImage;
                Player2Image.sprite = LostImage;


            }
            else
            {
                WinnerName = "SPELER 2";
                Player1Image.sprite = LostImage;
                Player2Image.sprite = WonImage;

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


    