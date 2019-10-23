using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour {

    [SerializeField]
    private float force;

    Vector3 direction = new Vector3(0.5f, -2, 1);

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Add a force to the ball when entering the box
    private void OnTriggerEnter(Collider other)
    {
        rb = other.GetComponent<Rigidbody>();
        rb.AddForce(rb.velocity.normalized * force, ForceMode.Force);
    }
}
