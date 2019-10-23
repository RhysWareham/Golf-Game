using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

    public GameObject destination;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Teleport ball to new position when colliding with the teleport
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.position = destination.transform.position;
    }
}
