using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallPottedScript : MonoBehaviour {

    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject endGameMenu;
    [SerializeField]
    private GameObject display;
    [SerializeField]
    public LevelTrackerScript level;

	// Use this for initialization
	void Start () {
        level = GameObject.Find("LevelTracker").GetComponent<LevelTrackerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //When ball is potted, open the menu
    //If there are no more levels, open the end of game menu
    private void OnTriggerEnter(Collider other)
    {
        if(level.levelNo == level.parNo.Length)
        {
            endGameMenu.SetActive(true);
        }
        else
        {
            menu.SetActive(true);
        }
        
        display.SetActive(false);
    }
}
