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


    // Start is called before the first frame update
    void Start()
    {
        //setting variables at the beginning
        scoreP1 = 0;
        scoreP2 = 0;
        addValueL = 34;
        addValueR = 34;
        leftPosition.transform.position -= new Vector3(0, 36) * 2;
        rightPosition.transform.position -= new Vector3(0, 36) * 2;
     }

    // Update is called once per frame
    void Update()
    {
        scoreP1Preff = PlayerPrefs.GetInt("Player1Score");
        scoreP2Preff = PlayerPrefs.GetInt("Player2Score");

        //if someone score 2 points there should appear a brick in the scorebar if there are 22 bricks no more brick should spawn
        if (scoreP1 + 2 == scoreP1Preff && maxBrickCountLeft < 22){

            scoreP1 = scoreP1Preff;

            //spawn the brick and move it on top of the previous one
            GameObject newBrickL = Instantiate(brickPrefab, leftPosition);

            //checks if the brick is an even brick
            if (maxBrickCountLeft % 2 == 0)
            {
               randomIntL = 10;
            }
            else
            {
               randomIntL = -10;
            }
            newBrickL.transform.position += new Vector3(randomIntL , addValueL);
            addValueL += 32;

            maxBrickCountLeft++;
        }

        //if someone score 2 points there should appear a brick in the scorebar if there are 22 bricks no more brick should spawn
        if (scoreP2 + 2 == scoreP2Preff && maxBrickCountRight < 22){ 
        
            scoreP2 = scoreP2Preff;

            //spawn the brick and move it on top of the previous one
            GameObject newBrickR =  Instantiate(brickPrefab, rightPosition);

            //checks if the brick is an even brick
            if (maxBrickCountRight % 2 == 0)
            {
                randomIntR = 10;
            }
            else
            {
                randomIntR = -10;
            }
            newBrickR.transform.position += new Vector3(randomIntR, addValueR);
            addValueR += 32;

            maxBrickCountRight++;
        }
    }
}
