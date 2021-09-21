using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnScreenTimerController : MonoBehaviour
{
    // text value arrays for the counter because the font exist out of 3 layered fonts
    public Text[] Min1Counters;
    public Text[] Min2Counters;
    public Text[] Sec1Counters;
    public Text[] Sec2Counters;

    // time duration of the game in frames
    public bool timeGoing;
    public bool gameEnded = false;
    private float timeRemaining = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        timeGoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        // check if time is going so that you can substract 
        if (timeGoing)
        {
            if (timeRemaining > 0)
            {
                // count down the time
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                gameEnded = true;
                // show gameover screen
                Debug.Log("Time has run out!");

                //for each number set the text (foreach because the text exist out of 3 fonts stacked)
                foreach (Text number in Min1Counters)
                {
                    number.text = "0";
                }
                foreach (Text number in Min2Counters)
                {
                    number.text = "0";
                }
                foreach (Text number in Sec1Counters)
                {
                    number.text = "0";
                }
                foreach (Text number in Sec2Counters)
                {
                    number.text = "0";
                }
                timeGoing = false;
            }
        }
    }

    // public function to start the timer, can be called in other scripts
    public void BeginTimer()
    {
        timeGoing = true;
        StartCoroutine(UpdateTimer());
    }

    //update for the timer
    private IEnumerator UpdateTimer()
    {
        while (timeGoing)
        {
            //calculate the time remaining in minutes and seconds instead of frames
            int minutes = Mathf.FloorToInt(timeRemaining / 60F);
            int seconds = Mathf.FloorToInt(timeRemaining - minutes * 60);

            //Add values for every number because of isometric perspective
            string sec2 = "0";
            string min2 = "0";
            string sec1 = "0";
            string min1 = "0";

            //If the numbers are lower then dubble digits
            if (seconds < 10)
            {
                sec1 = "0";
                sec2 = seconds.ToString()[0].ToString();

            }
            else
            {
                sec1 = seconds.ToString()[0].ToString();
                //Debug.Log(sec2 = seconds.ToString()[1].ToString());
            }

            //If the numbers are lower then dubble digits
            if (minutes < 10)
            {
                min1 = "0";
                min2 = minutes.ToString()[0].ToString();

            }
            else
            {
                min1 = minutes.ToString()[0].ToString();
                //Debug.Log(min2 = minutes.ToString()[1].ToString());

            }

            //for each number set the text (foreach because the text exist out of 3 fonts stacked)
            foreach (Text number in Min1Counters)
            {
                number.text = min1;
            }

            foreach (Text number in Min2Counters)
            {
                number.text = min2;
            }

            foreach (Text number in Sec1Counters)
            {
                number.text = sec1;
            }

            foreach (Text number in Sec2Counters)
            {
                number.text = sec2;
            }
            yield return null;

        }
    }
}
