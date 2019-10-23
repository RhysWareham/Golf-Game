using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenuScript : MonoBehaviour {

    [SerializeField]
    private LevelTrackerScript score;

    [SerializeField]
    private Text shotTotalText;
    [SerializeField]
    private Text parTotalText;
    [SerializeField]
    private Button mainMenuButton;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("LevelTracker").GetComponent<LevelTrackerScript>();
        //Set the total shots text to display the total amount of shots throughout entire game
        shotTotalText.text = "Total Shots: " + score.totalShots;
        //Set the total par text to display the total amount of shots needed to get a par in entire game
        parTotalText.text = "Par Total: " + score.totalPar;
	}
	
	// Update is called once per frame
	void Update () {
        mainMenuButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(1));
    }

    //If main menu button clicked, load the main menu scene and set variables back to initial values
    void ButtonClicked(int buttonNo)
    {
        SceneManager.LoadScene("MainMenu");
        score.totalShots = 0;
        score.totalPar = 0;
        score.demoDone = false;
    }
}
