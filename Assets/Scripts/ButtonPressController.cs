using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressController : MonoBehaviour
{
    public GameController gameController;
    private RandomPopUpObject ActiveElementButton;
    private GameObject ActiveElement;

    public SerialController serialController;

    private AudioSource hitSound;

    public GameObject plusOne;

    Animator anim;
    int hithash = Animator.StringToHash("Ishit");

    void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        //getting serial controller for arduino connection
        serialController = GameObject.Find("SerialController").GetComponent<SerialController>();
    }
 
    void Update()
    {
        if (gameController.gameIsActive == true)
        {

            //Get keyinputs For the 1st player

            //1ste row of object
            if (Input.GetKeyDown("q"))
            {
                //find item that you want to activate with the key and select the script
                ActiveElement = GameObject.Find("BL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();

                //if the item is up, it can be hit so add score to corresponding player
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    //spawn object that shows the hit
                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);


                    //deactivate the object and move it down
                    ActiveElementButton.isHit = true;

                    //get the player score and add a point
                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //send to arduino that hit has happened
                    serialController.SendSerialMessage("01");

                    //save the score in the PlayerPrefs for display of the score
                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }
            //repeat for every gameobject and button

            if (Input.GetKeyDown("w"))
            {
                ActiveElement = GameObject.Find("BM-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {

                    ActiveElementButton.Down = true;
                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 1");
                    serialController.SendSerialMessage("11");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //2nd row of objects
            if (Input.GetKeyDown("e"))
            {
                ActiveElement = GameObject.Find("BR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 2");
                    serialController.SendSerialMessage("21");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("r"))
            {
                ActiveElement = GameObject.Find("M1L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 3");
                    serialController.SendSerialMessage("31");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("t"))
            {
                ActiveElement = GameObject.Find("M1R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 4");
                    serialController.SendSerialMessage("41");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //3rd row of objects
            if (Input.GetKeyDown("y"))
            {
                ActiveElement = GameObject.Find("M2L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 5");
                    serialController.SendSerialMessage("51");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("u"))
            {
                ActiveElement = GameObject.Find("M2M-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);
 
                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 6");
                    serialController.SendSerialMessage("61");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("i"))
            {
                ActiveElement = GameObject.Find("M2R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 7");
                    serialController.SendSerialMessage("71");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //4th row of objects
            if (Input.GetKeyDown("o"))
            {
                ActiveElement = GameObject.Find("TL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 8");
                    serialController.SendSerialMessage("81");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("p"))
            {
                ActiveElement = GameObject.Find("TR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P1Score = PlayerPrefs.GetInt("Player1Score");
                    P1Score++;

                    //Debug.Log("Sending 9");
                    serialController.SendSerialMessage("91");

                    PlayerPrefs.SetInt("Player1Score", P1Score);
                    PlayerPrefs.Save();
                }
            }

            //---------------------------------------------------------------------------------//

            // get keyinputs for the 2nd player
            //1ste row of object 
            if (Input.GetKeyDown("a"))
            {
                ActiveElement = GameObject.Find("BL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 0");
                    serialController.SendSerialMessage("02");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("s"))
            {
                ActiveElement = GameObject.Find("BM-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 1");
                    serialController.SendSerialMessage("12");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            //2nd row of objects
            if (Input.GetKeyDown("d"))
            {
                ActiveElement = GameObject.Find("BR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 2");
                    serialController.SendSerialMessage("22");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }
            if (Input.GetKeyDown("f"))
            {
                ActiveElement = GameObject.Find("M1L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 3");
                    serialController.SendSerialMessage("32");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }
            if (Input.GetKeyDown("g"))
            {
                ActiveElement = GameObject.Find("M1R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 4");
                    serialController.SendSerialMessage("42");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            //3rd row of objects
            if (Input.GetKeyDown("h"))
            {
                ActiveElement = GameObject.Find("M2L-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 5");
                    serialController.SendSerialMessage("52");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("j"))
            {
                ActiveElement = GameObject.Find("M2M-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 6");
                    serialController.SendSerialMessage("62");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown("k"))
            {
                ActiveElement = GameObject.Find("M2R-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 7");
                    serialController.SendSerialMessage("72");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            //4th row of objects
            if (Input.GetKeyDown("l"))
            {
                ActiveElement = GameObject.Find("TL-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(2, 1);

                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 8");
                    serialController.SendSerialMessage("82");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
            }

            if (Input.GetKeyDown(","))
            {
                ActiveElement = GameObject.Find("TR-Popup");
                ActiveElementButton = ActiveElement.GetComponent<RandomPopUpObject>();
                if (ActiveElementButton.Down == false)
                {
                    ActiveElementButton.Down = true;

                    //play animation and add sound
                    anim = ActiveElement.GetComponentInParent<Animator>();
                    hitSound = ActiveElement.GetComponent<AudioSource>();
                    anim.SetTrigger(hithash);
                    hitSound.Play();

                    ActiveElementButton.plusOne = Instantiate(plusOne, ActiveElement.transform.position, Quaternion.identity);
                    plusOne.transform.position += new Vector3(-2, -1);
                     
                    ActiveElementButton.isHit = true;

                    int P2Score = PlayerPrefs.GetInt("Player2Score");
                    P2Score++;

                    //Debug.Log("Sending 9");
                    serialController.SendSerialMessage("92");

                    PlayerPrefs.SetInt("Player2Score", P2Score);
                    PlayerPrefs.Save();
                }
                }
            }
        }
    }
