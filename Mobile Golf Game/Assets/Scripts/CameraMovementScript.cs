using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementScript : MonoBehaviour {

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private BallMovementScript ball;
    Vector2 rotateAmount;
    Vector3 desiredPosition;
    Vector2 previousTouchPos;

    
    private OptionsMenu slider;
    public static float rotationSpeed = 200.0f;
    [SerializeField]
    float radius = 3.0f;
    float radiusSpeed = 50.0f;


	// Use this for initialization
	void Start () {
        desiredPosition = (transform.position - target.transform.position).normalized * radius + target.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        rotateAmount = CalculateCameraMovement();
        CameraRotation(rotateAmount);
	}

    //Rotate the camera and keep camera at certain distance from ball
    private void CameraRotation(Vector2 rotateAmount)
    {
        if (ball.allowChangeDirection == true)
        {
            if (Mathf.Abs(rotateAmount.x + rotateAmount.y) > 1)
            {
                transform.RotateAround(target.transform.position, new Vector3(0, rotateAmount.x, 0), rotationSpeed * Time.deltaTime);
            }
        }

        desiredPosition = (transform.position - target.transform.position).normalized * radius + target.transform.position;
        desiredPosition = new Vector3(desiredPosition.x, target.transform.position.y + 1.459881f, desiredPosition.z);
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);
        
        transform.LookAt(target.transform);
        
        
    }

    //Calculate how much to move the camera by
    Vector2 CalculateCameraMovement()
    {
        Vector2 fingerMovement = Vector2.zero;

        if(Input.touchCount > 0)
        {
            Touch currentTouchPos = Input.GetTouch(0);

            fingerMovement = (currentTouchPos.position - previousTouchPos);
            previousTouchPos = currentTouchPos.position;
        }
        else
        {
            fingerMovement = Vector2.zero;
        }

        return fingerMovement;
    }
}
