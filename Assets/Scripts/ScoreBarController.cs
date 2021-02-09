using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBarController : MonoBehaviour
{
    //get the brick prefab
    public GameObject brickPrefab;

    //set the left and right position on the scorebar
    public Transform leftPosition;
    public Transform rightPosition;

    private int scoreP1;
    private int scoreP1Preff;

    private int scoreP2;
    private int scoreP2Preff;

    private int addValueL;
    private int addValueR;

    private int maxBrickCountLeft;
    private int maxBrickCountRight;

    private int randomIntL;
    private int randomIntR;

    private int BrickPaternCounterL;
    private int BrickPaternCounterR;

    // Start is called before the first frame update
    void Start()
    {
        //setting variables at the beginning
        scoreP1 = 0;
        scoreP2 = 0;
        addValueL = 28;
        addValueR = 28;
        leftPosition.transform.position -= new Vector3(0, 36) * 2;
        rightPosition.transform.position -= new Vector3(0, 36) * 2;
        BrickPaternCounterL = 1;
        BrickPaternCounterR = 1;
     }

    // Update is called once per frame
    void Update()
    {
        scoreP1Preff = PlayerPrefs.GetInt("Player1Score");
        scoreP2Preff = PlayerPrefs.GetInt("Player2Score");

        //if someone score 2 points there should appear a brick in the scorebar if there are 22 bricks no more brick should spawn
        if (scoreP1 + 1 == scoreP1Preff && maxBrickCountLeft < 65){

            scoreP1 = scoreP1Preff;

            //spawn the brick and move it on top of the previous one
            GameObject newBrickL = Instantiate(brickPrefab, leftPosition);

            //checks if the brick is an even brick
            if (BrickPaternCounterL == 1)
            {
                if(maxBrickCountLeft > 0)
                {
                    addValueL += 18;
                }
                randomIntL = -20;
                BrickPaternCounterL = 2;
            }
            else if (BrickPaternCounterL == 2)
            {
                randomIntL = 20;
                BrickPaternCounterL = 3;
            }
            else
            {
                randomIntL = 0;
                addValueL += 18;
                BrickPaternCounterL = 1;
            }

            newBrickL.transform.position += new Vector3(randomIntL , addValueL);
            maxBrickCountLeft++;
        }

        //if someone score 2 points there should appear a brick in the scorebar if there are 22 bricks no more brick should spawn
        if (scoreP2 + 1 == scoreP2Preff && maxBrickCountRight < 65){ 
        
            scoreP2 = scoreP2Preff;

            //spawn the brick and move it on top of the previous one
            GameObject newBrickR =  Instantiate(brickPrefab, rightPosition);

            //checks if the brick is an even brick
            if (BrickPaternCounterR == 1)
            {
                if (maxBrickCountRight > 0)
                {
                    addValueR += 18;
                }
                randomIntR = -20;
                BrickPaternCounterR = 2;
            }
            else if (BrickPaternCounterR == 2)
            {
                randomIntR = 20;
                BrickPaternCounterR = 3;
            }
            else
            {
                randomIntR = 0;
                addValueR += 18;
                BrickPaternCounterR = 1;
            }

            newBrickR.transform.position += new Vector3(randomIntR, addValueR);
            maxBrickCountRight++;
        }
    }
}
