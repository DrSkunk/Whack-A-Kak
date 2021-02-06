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

    // Start is called before the first frame update
    void Start()
    {
        //setting variables at the beginning
        scoreP1 = 0;
        scoreP2 = 0;
        addValueL = 36;
        addValueR = 36;
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
            int randomIntL = Mathf.FloorToInt(Random.Range(0f, 5f));
            newBrickL.transform.position += new Vector3(randomIntL , addValueL);
            addValueL += 34;

            maxBrickCountLeft++;
        }

        //if someone score 2 points there should appear a brick in the scorebar if there are 22 bricks no more brick should spawn
        if (scoreP2 + 2 == scoreP2Preff && maxBrickCountRight < 22){ 
        
            scoreP2 = scoreP2Preff;

            //spawn the brick and move it on top of the previous one
            GameObject newBrickR =  Instantiate(brickPrefab, rightPosition);
            int randomIntR = Mathf.FloorToInt(Random.Range(0f, 5f));
            newBrickR.transform.position += new Vector3(randomIntR, addValueR);
            addValueR += 34;

            maxBrickCountRight++;
        }
    }
}
