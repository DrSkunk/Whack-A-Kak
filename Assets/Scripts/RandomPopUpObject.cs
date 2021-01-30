using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPopUpObject : MonoBehaviour
{
    //public variables so that you can acces them in other files.

    public bool active = false;
    public bool Down = true;

    private float loadTimer;

    void Update()
    {
        //active state is set in the popup controller and accessed by the buttonPressController
        if (active)
        {
            Down = false;
            gameObject.transform.Translate(Vector3.up * 2);
            // choose a random time to be active
            loadTimer = Random.Range(0.5f, 1.3f);
            active = false;
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
            gameObject.transform.Translate(Vector3.down * 2);
            Down = true;

        }
    }
}