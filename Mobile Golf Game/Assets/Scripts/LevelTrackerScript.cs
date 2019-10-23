using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrackerScript : MonoBehaviour {

    public int levelNo = 0;
    //NUmber of shots for a par for each hole
    public int[] parNo = new int[8] { 1, 2, 1, 4, 6, 3, 2, 3 };
    public int totalPar;
    public int totalShots = 0;
    public bool demoDone = false;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
        //Find the total number of shots to get a par in the entire game
        for(int i = 0; i < parNo.Length; i++)
        {
            totalPar += parNo[i];
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
