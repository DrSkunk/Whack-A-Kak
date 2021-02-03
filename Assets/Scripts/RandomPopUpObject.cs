using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPopUpObject : MonoBehaviour
{
    //public variables so that you can acces them in other files.

    public bool active = false;
    public bool Down = true;

    private float loadTimer;

    public SerialController serialController;

    void Start()
    {
        active = false;
        Down = true;
        //getting serial controller for arduino connection
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }

    void Update()
    {
        //active state is set in the popup controller and accessed by the buttonPressController
        if (active)
        {
            active = false;
            gameObject.transform.Translate(Vector3.up * 2);
            Down = false;
            // choose a random time to be active
            loadTimer = Random.Range(3.0f, 5.0f);

            //arduino
                //schrijven wanneer high 
                if(gameObject.name == "BR-Popup"){
                    //Debug.Log("Sending A");
                    serialController.SendSerialMessage("A");
                }
                if(gameObject.name == "BM-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("Z");
                }
                if(gameObject.name == "BL-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("E");
                }
                if(gameObject.name == "M1R-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("R");
                }
                if(gameObject.name == "M1L-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("T");
                }
                if(gameObject.name == "M2L-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("Y");
                }
                if(gameObject.name == "M2M-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("U");
                }
                if(gameObject.name == "M2R-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("I");
                }
                if(gameObject.name == "TR-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("O");
                }
                if(gameObject.name == "TL-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("P");
                }


            //Use Couroutine to make code wait
            StartCoroutine(function());
        }

    }


    IEnumerator function()
    {
        if(Down == false)
        {
            //IEnumerator waits at this line untill timer has run out
            yield return new WaitForSeconds(loadTimer);
            //active = false;
            gameObject.transform.Translate(Vector3.down * 2);
            Down = true;

                //arduino
                //schrijven wanneer low
                if(gameObject.name == "BR-Popup"){
                    //Debug.Log("Sending A");
                    serialController.SendSerialMessage("Q");
                }
                if(gameObject.name == "BM-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("S");
                }
                if(gameObject.name == "BL-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("D");
                }
                if(gameObject.name == "M1R-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("F");
                }
                if(gameObject.name == "M1L-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("G");
                }
                if(gameObject.name == "M2L-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("H");
                }
                if(gameObject.name == "M2M-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("J");
                }
                if(gameObject.name == "M2R-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("K");
                }
                if(gameObject.name == "TR-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("L");
                }
                if(gameObject.name == "TL-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("M");
                }

        }
    }
}

