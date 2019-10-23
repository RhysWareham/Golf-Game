using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrackerScript : MonoBehaviour {

    public int shotsTaken;
    private int prevShotsTaken;
    [SerializeField]
    private Text shotText;
    [SerializeField]
    private Text levelText;
    [SerializeField]
    public LevelTrackerScript level;

	// Use this for initialization
	void Start () {
        level = GameObject.Find("LevelTracker").GetComponent<LevelTrackerScript>();
        shotsTaken = 1;
        shotText.text = "Shot Number: " + shotsTaken;
        if (level.levelNo == 0)
        {
            levelText.text = "Tutorial Level";
        }
        else
        {
            levelText.text = "Hole Number: " + level.levelNo;
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(shotsTaken > prevShotsTaken)
        {
            prevShotsTaken = shotsTaken;
            increaseScore(shotsTaken);
        }
	}

    //Increase the shots taken text
    //Increase total shots taken in game
    void increaseScore(int shotsTaken)
    {
        shotText.text = "Shot Number: " + shotsTaken;
        level.totalShots++;
    }
}
