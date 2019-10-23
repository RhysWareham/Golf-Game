using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDoorScript : MonoBehaviour {

    [SerializeField]
    private GameObject door;
    private bool moveDoor = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //If moveDoor is true, move the door upwards
		if(moveDoor == true && door.transform.position.y < 10)
        {
            door.transform.Translate(Vector3.up * 1f * Time.deltaTime, Space.Self);
        }
	}
    
    //If ball hits the button, set moveDoor to true
    private void OnTriggerEnter(Collider other)
    {
        moveDoor = true;
    }
    
  
}
