using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPopUpObject : MonoBehaviour
{
    //public variables so that you can acces them in other files.

    public bool active = false;
    public bool Down = true;
    public bool isHit = false;

    public float loadTimer;

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
            loadTimer = Random.Range(1.0f, 1.0f);

            //arduino
                //schrijven wanneer high 
                if(gameObject.name == "BR-Popup"){
                    Debug.Log("Sending A");
                    serialController.SendSerialMessage("A0");
                }
                if(gameObject.name == "BM-Popup"){
                    Debug.Log("Sending Z");
                    serialController.SendSerialMessage("Z0");
                }
                if(gameObject.name == "BL-Popup"){
                    Debug.Log("Sending E");
                    serialController.SendSerialMessage("E0");
                }
                if(gameObject.name == "M1R-Popup"){
                    Debug.Log("Sending R");
                    serialController.SendSerialMessage("R0");
                }
                if(gameObject.name == "M1L-Popup"){
                    Debug.Log("Sending T");
                    serialController.SendSerialMessage("T0");
                }
                if(gameObject.name == "M2L-Popup"){
                    Debug.Log("Sending Y");
                    serialController.SendSerialMessage("Y0");
                }
                if(gameObject.name == "M2M-Popup"){
                    Debug.Log("Sending U");
                    serialController.SendSerialMessage("U0");
                }
                if(gameObject.name == "M2R-Popup"){
                    Debug.Log("Sending I");
                    serialController.SendSerialMessage("I0");
                }
                if(gameObject.name == "TR-Popup"){
                    Debug.Log("Sending O");
                    serialController.SendSerialMessage("O0");
                }
                if(gameObject.name == "TL-Popup"){
                    Debug.Log("Sending P");
                    serialController.SendSerialMessage("P0");
                }


            //Use Couroutine to make code wait
            StartCoroutine(MoveDownAfterTime());

        }
        if (isHit == true)
        {
            StopAllCoroutines();
            loadTimer = 1f;
            StartCoroutine(MoveDownAfterTime());
            isHit = false;
            Debug.Log(Down.ToString() + " name of the object is : " + gameObject.name);

        }

    }


    IEnumerator MoveDownAfterTime()
    {
        if (Down == true && isHit == true)
        {
            yield return new WaitForSeconds(1);
            gameObject.transform.Translate(Vector3.down * 2);
        }


        if (Down == false)
        {

                //IEnumerator waits at this line untill timer has run out
                isHit = false;
                Debug.Log("im whaiting this long to go down" + loadTimer);
                yield return new WaitForSeconds(loadTimer);
                Debug.Log("im done");
                //active = false;
                gameObject.transform.Translate(Vector3.down * 2);
                Down = true;

                //arduino
                //schrijven wanneer low
                if(gameObject.name == "BR-Popup"){
                    Debug.Log("Sending Q");
                    serialController.SendSerialMessage("Q0");
                }
                if(gameObject.name == "BM-Popup"){
                    Debug.Log("Sending S");
                    serialController.SendSerialMessage("S0");
                }
                if(gameObject.name == "BL-Popup"){
                    Debug.Log("Sending D");
                    serialController.SendSerialMessage("D0");
                }
                if(gameObject.name == "M1R-Popup"){
                    Debug.Log("Sending F");
                    serialController.SendSerialMessage("F0");
                }
                if(gameObject.name == "M1L-Popup"){
                    Debug.Log("Sending G");
                    serialController.SendSerialMessage("G0");
                }
                if(gameObject.name == "M2L-Popup"){
                    Debug.Log("Sending H");
                    serialController.SendSerialMessage("H0");
                }
                if(gameObject.name == "M2M-Popup"){
                    Debug.Log("Sending J");
                    serialController.SendSerialMessage("J0");
                }
                if(gameObject.name == "M2R-Popup"){
                    Debug.Log("Sending K");
                    serialController.SendSerialMessage("K0");
                }
                if(gameObject.name == "TR-Popup"){
                    Debug.Log("Sending L");
                    serialController.SendSerialMessage("L0");
                }
                if(gameObject.name == "TL-Popup"){
                    Debug.Log("Sending M");
                    serialController.SendSerialMessage("M0");
                }
        }
             
    }
}

