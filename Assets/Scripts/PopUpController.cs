using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour
{
    public GameController gameController;
    //add gameobjects to array to choose your items to pop up
    public GameObject[] GameElements;
    public float nextActiveCycle;

    private bool hasSetActive = false;
    private RandomPopUpObject activeElement;



    void Update()
    {
        if (gameController.gameIsActive == true)
        {
            if (Time.time > nextActiveCycle) // if time is greater than nextActiveCycle activate object
            {
                //select a random element from al the game elements to pop up.
                activeElement = GameElements[Random.Range(0, GameElements.Length)].GetComponent<RandomPopUpObject>();
                //choose random moment to choose a other item.
                nextActiveCycle = Time.time + Random.Range(0.5f, 2.0f); ;
                hasSetActive = false;
                }
           

            }

            //check if an item can popup
            if (hasSetActive == false)
            {
                foreach (GameObject GameElement in GameElements)
                {
                    //get the RandomPopUpObject script to check active variables on true
                    if(GameElement.GetComponent<RandomPopUpObject>() == activeElement)
                    {
                        //if item is already active set it inactive else put it active so it pops up
                        if(activeElement.active == true)
                        {
                            activeElement.active = false;
                        }
                        else
                        {
                            activeElement.active = true;
                        }
                    }
                }
                //prevent infinite cycle without timer
                hasSetActive = true;
            }
        }
    }


