using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressController : MonoBehaviour
{
    public GameController gameController;
    private RandomPopUpObject ActiveElementButton;
    private GameObject ActiveElement;
 
    void Update()
    {
        if (gameController.gameIsActive == true)
        {

            //Get keyinputs For the 1st player

            //1ste row of object
            if (Input.GetKeyDown("z"))
            {
                //find item that you want to activate with the key and select the script
                ActiveElement = GameObject.Find("BL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();

                //if the item is up, it can be hit so add score to corresponding player
                if (ActiveElementButton.Down == false)
                {
                    //deactivate the object and move it down
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;

                    //get the player score and add a point
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //save the score in the PlayerPrefs for display of the score
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }
            //repeat for every gameobject and button

            if (Input.GetKeyDown("x"))
            {
                ActiveElement = GameObject.Find("BM-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //2nd row of objects
            if (Input.GetKeyDown("c"))
            {
                ActiveElement = GameObject.Find("BR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("s"))
            {
                ActiveElement = GameObject.Find("M1L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("d"))
            {
                ActiveElement = GameObject.Find("M1R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //3rd row of objects
            if (Input.GetKeyDown("q"))
            {
                ActiveElement = GameObject.Find("M2L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("w"))
            {
                ActiveElement = GameObject.Find("M2M-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("e"))
            {
                ActiveElement = GameObject.Find("M2R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //4th row of objects
            if (Input.GetKeyDown("1"))
            {
                ActiveElement = GameObject.Find("TL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("2"))
            {
                ActiveElement = GameObject.Find("TR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //---------------------------------------------------------------------------------//

            // get keyinputs for the 2nd player
            //1ste row of object 
            if (Input.GetKeyDown("n"))
            {
                ActiveElement = GameObject.Find("BL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown(","))
            {
                ActiveElement = GameObject.Find("BM-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            //2nd row of objects
            if (Input.GetKeyDown("."))
            {
                ActiveElement = GameObject.Find("BR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }
            if (Input.GetKeyDown("j"))
            {
                ActiveElement = GameObject.Find("M1L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }
            if (Input.GetKeyDown("k"))
            {
                ActiveElement = GameObject.Find("M1R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            //3rd row of objects
            if (Input.GetKeyDown("u"))
            {
                ActiveElement = GameObject.Find("M2L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("i"))
            {
                ActiveElement = GameObject.Find("M2M-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("o"))
            {
                ActiveElement = GameObject.Find("M2R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            //4th row of objects
            if (Input.GetKeyDown("8"))
            {
                ActiveElement = GameObject.Find("TL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("9"))
            {
                ActiveElement = GameObject.Find("TR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
            
                    ActiveElementButton.Down = true;
                    ActiveElementButton.active = false;
                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;
                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }
        }
    }
