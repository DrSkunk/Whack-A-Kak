using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPopUpObject : MonoBehaviour
{
    //public variables so that you can acces them in other files.
    public bool active = false;
    public bool Down = true;
    public bool inloop = false;

    //bool to check it the object is hit
    public bool isHit = false;
    public float loadTimer;

    //the plusone object that popup on hit
    public GameObject plusOne;

    //serial controller for the arduino
    public SerialController serialController;
    public SerialController serialController2;

    void Start()
    {
        //setting the variables at the start of the game
        active = false;
        Down = true;
        inloop = false;

        //getting serial controller for arduino connection
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
        serialController2 = GameObject.Find("SerialController2").GetComponent<SerialController>();
    }

    void Update()
    {
        //active state is set in the popup controller and accessed by the buttonPressController
        if (active)
        {
            active = false;
            //move object up
            gameObject.transform.Translate(Vector3.up * 2);
            // choose a random time to be active
            Down = false;
            loadTimer = Random.Range(1.0f, 1.0f);

            //arduino
                //Write to arduino when high
                if(gameObject.name == "BR-Popup"){
                    //Debug.Log("Sending A");
                    serialController.SendSerialMessage("A0");
                    serialController2.SendSerialMessage("A0");
                }
                if(gameObject.name == "BM-Popup"){
                    //Debug.Log("Sending Z");
                    serialController.SendSerialMessage("Z0");
                    serialController2.SendSerialMessage("Z0");
                }
                if(gameObject.name == "BL-Popup"){
                    //Debug.Log("Sending E");
                    serialController.SendSerialMessage("E0");
                    serialController2.SendSerialMessage("E0");
                }
                if(gameObject.name == "M1R-Popup"){
                    //Debug.Log("Sending R");
                    serialController.SendSerialMessage("R0");
                    serialController2.SendSerialMessage("R0");
                }
                if(gameObject.name == "M1L-Popup"){
                    //Debug.Log("Sending T");
                    serialController.SendSerialMessage("T0");
                    serialController2.SendSerialMessage("T0");
                }
                if(gameObject.name == "M2L-Popup"){
                   //Debug.Log("Sending Y");
                    serialController.SendSerialMessage("Y0");
                    serialController2.SendSerialMessage("Y0");
                }
                if(gameObject.name == "M2M-Popup"){
                    //Debug.Log("Sending U");
                    serialController.SendSerialMessage("U0");
                    serialController2.SendSerialMessage("U0");
                }
                if(gameObject.name == "M2R-Popup"){
                    //Debug.Log("Sending I");
                    serialController.SendSerialMessage("I0");
                    serialController2.SendSerialMessage("I0");
                }
                if(gameObject.name == "TR-Popup"){
                    //Debug.Log("Sending O");
                    serialController.SendSerialMessage("O0");
                    serialController2.SendSerialMessage("O0");
                }
                if(gameObject.name == "TL-Popup"){
                    //Debug.Log("Sending P");
                    serialController.SendSerialMessage("P0");
                    serialController2.SendSerialMessage("P0");
                }


            //Use Couroutine to make code wait
            StartCoroutine(MoveDownAfterTime());

        }
        //if the object it hit the timer needs to stop and be 1 sec
        if (isHit == true)
        {
            StopAllCoroutines();
            loadTimer = 1f;
            StartCoroutine(MoveDownAfterTime());
            isHit = false;

        }

    }


    IEnumerator MoveDownAfterTime()
    {
        inloop = true;

        //IEnumerator waits at this line untill timer has run ou
        yield return new WaitForSeconds(loadTimer);
        inloop = false;
        Down = true;
        gameObject.transform.Translate(Vector3.down * 2);


        //destroy the plusone object after the object goes down
        Destroy(plusOne);

        isHit = false;
        //arduino
        //Write to arduino when low
        if (gameObject.name == "BR-Popup"){
                   // Debug.Log("Sending Q");
                    serialController.SendSerialMessage("Q0");
                    serialController2.SendSerialMessage("Q0");
                }
                if(gameObject.name == "BM-Popup"){
                    //Debug.Log("Sending S");
                    serialController.SendSerialMessage("S0");
                    serialController2.SendSerialMessage("S0");
                }
                if(gameObject.name == "BL-Popup"){
                    //Debug.Log("Sending D");
                    serialController.SendSerialMessage("D0");
                    serialController2.SendSerialMessage("D0");
                }
                if(gameObject.name == "M1R-Popup"){
                    //Debug.Log("Sending F");
                    serialController.SendSerialMessage("F0");
                    serialController2.SendSerialMessage("F0");
                }
                if(gameObject.name == "M1L-Popup"){
                    //Debug.Log("Sending G");
                    serialController.SendSerialMessage("G0");
                    serialController2.SendSerialMessage("G0");
                }
                if(gameObject.name == "M2L-Popup"){
                    //Debug.Log("Sending H");
                    serialController.SendSerialMessage("H0");
                    serialController2.SendSerialMessage("H0");
                }
                if(gameObject.name == "M2M-Popup"){
                    //Debug.Log("Sending J");
                    serialController.SendSerialMessage("J0");
                    serialController2.SendSerialMessage("J0");
                }
                if(gameObject.name == "M2R-Popup"){
                    //Debug.Log("Sending K");
                    serialController.SendSerialMessage("K0");
                    serialController2.SendSerialMessage("K0");
                }
                if(gameObject.name == "TR-Popup"){
                   //Debug.Log("Sending L");
                    serialController.SendSerialMessage("L0");
                    serialController2.SendSerialMessage("L0");
                }
                if(gameObject.name == "TL-Popup"){
                    //Debug.Log("Sending M");
                    serialController.SendSerialMessage("M0");
                    serialController2.SendSerialMessage("M0");
                }  
    }
}

