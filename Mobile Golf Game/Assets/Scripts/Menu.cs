using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button optionsButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private Button backButton;

    [SerializeField]
    private GameObject options;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(1));
        optionsButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(2));
        quitButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(3));
        backButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(4));
    }

    void ButtonClicked(int buttonNo)
    {
        //If play button is clicked, load first level
        if(buttonNo == 1)
        {
            SceneManager.LoadScene("Level0");
        }
        //If options button is clicked, show options menu
        else if (buttonNo == 2)
        {
            gameObject.SetActive(false);
            options.SetActive(true);
        }
        //If quit button is clicked, close application
        else if (buttonNo == 3)
        {
            Application.Quit();
        }
        //If back button is clicked, go back to main menu
        else if (buttonNo == 4)
        {
            gameObject.SetActive(true);
            options.SetActive(false);
        }
    }
}
