using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Change the rotation sensitivity depending on the value from the slider
    public void AdjustSensitivity(float value)
    {
        CameraMovementScript.rotationSpeed = value;
    }
}
