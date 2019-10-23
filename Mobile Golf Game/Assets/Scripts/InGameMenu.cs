using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class InGameMenu : MonoBehaviour {

    [SerializeField]
    private Button nextButton;

    [SerializeField]
    private Button tryAgainButton;


    [SerializeField]
    private ScoreTrackerScript score;

    [SerializeField]
    private Text shotText;
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text parText;

    bool increasedLevel;

    // Use this for initialization
    void Start ()
    {
        //Set shot taken text to shot shotsTaken
        shotText.text = "Shots Taken: " + score.shotsTaken;

        //Set increasedLevel to false when level begins
        increasedLevel = false;
        
        //Set level number text to shot shotsTaken, unless on tutorial level
        if (score.level.levelNo == 0)
        {
            levelText.text = "Tutorial Level";
        }
        else
        {
            levelText.text = "Hole Number: " + score.level.levelNo;
        }
        parText.text = "Par: " + score.level.parNo[score.level.levelNo];
        
    }
	
	// Update is called once per frame
	void Update () {
        nextButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(1));
        tryAgainButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(2));

    }

    //If next level button is clicked, load next level
    //If try again button is clicked, reload level
    void ButtonClicked(int buttonNo)
    {
        if(buttonNo == 1)
        {
            //Check if the level has been increased once; if it has, don't increase the number more until the next level
            if(increasedLevel != true)
            {
                score.level.levelNo++;
                increasedLevel = true;
            }
            
            SceneManager.LoadScene("Level" + (score.level.levelNo));
        }
        if(buttonNo == 2)
        {
            SceneManager.LoadScene("Level" + score.level.levelNo);
            score.shotsTaken = 1;
        }
    }
}
