using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BallMovementScript : MonoBehaviour
{

    [SerializeField]
    private Rigidbody rbBall;
    [SerializeField]
    private GameObject lockButton;
    [SerializeField]
    private GameObject fireButton;
    [SerializeField]
    private ScoreTrackerScript score;
    [SerializeField]
    private GameObject directionHelp;
    [SerializeField]
    private GameObject powerHelp;

    public enum BallState
    {
        Stopped,
        ChangeDirection,
        ChangePower,
        AddForce,
        Moving
    }

    public BallState currentState;
    public float maxForce = 2000.0f;
    private float minForce = 0.0f;
    public float force;
    private float powerBarDirection = 1;
    private float powerBarChange = 10.0f;
    private Vector3 shootDirection;
    public bool allowChangeDirection = true;
    private Vector3 startPos;
    private Vector3 newPos;


    // Use this for initialization
    void Start()
    {
        startPos = new Vector3(-8.37f, 0.39f, 0.0f);
        //Find the ScoreTrackerScript to set to score
        score = GameObject.Find("HeadsUpDisplay").GetComponent<ScoreTrackerScript>();
        shootDirection = Vector2.zero;
        force = 0;
        rbBall = GetComponent<Rigidbody>() as Rigidbody;
        rbBall.transform.position = startPos;
        currentState = BallState.Stopped;
        fireButton.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //Switch case to move between direction change, power change, and moving the ball
        switch (currentState)
        {
            case BallState.Stopped:
                //If tutorial is not over, show hints
                if (score.level.demoDone == false)
                {
                    directionHelp.SetActive(true);
                }
                lockButton.SetActive(true);
                newPos = rbBall.transform.position;
                if (Input.touchCount > 0)
                {
                    currentState = BallState.ChangeDirection;
                }

                break;
            case BallState.ChangeDirection:
                allowChangeDirection = true;
                AdjustDirection();

                break;
            case BallState.ChangePower:
                lockButton.SetActive(false);
                fireButton.SetActive(true);
                allowChangeDirection = false;
                SetPower();
                

                break;
            case BallState.AddForce:
                AddForce(force, shootDirection);
                currentState = BallState.Moving;

                break;
            case BallState.Moving:
                fireButton.SetActive(false);
                CheckIsStationary();
                break;
        }


        if(rbBall.transform.position.y < -10)
        {
            rbBall.transform.position = newPos;
        }
    }

    //Adjust direction
    void AdjustDirection()
    {
        //Get the direction the camera is facing
        Vector3 currentCameraDirection = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);


        if (Input.touchCount == 0)
        {
            //Set direction to shoot
            shootDirection = currentCameraDirection;
        }
    }

    //Set power
    void SetPower()
    {
        //If tutorial is not over, show hints
        if (score.level.demoDone == false)
        {
            directionHelp.SetActive(false);
            powerHelp.SetActive(true);
        }
        if (Input.touchCount > 0)
        {
            int touchCount = Input.touchCount;

            if(touchCount == 0)
            {
                currentState = BallState.AddForce;
            }
            else
            {
                //Increase the value of the power bar
                float powerIncrease = powerBarChange * Time.deltaTime;

                //Make sure force doesn't go too high
                if((force + powerIncrease) > maxForce)
                {
                    force = maxForce;
                    powerBarDirection = -75;
                }
                //Make sure force doesn't go too low
                else if ((force - powerIncrease) < minForce)
                {
                    force = minForce;
                    powerBarDirection = 75;
                }

                force += (powerIncrease * powerBarDirection);

                
            }
        }
    }

    //Add force
    void AddForce(float force, Vector3 shootDirection)
    {
        if (score.level.demoDone == false)
        {
            powerHelp.SetActive(false);
            //Tutorial is over
            score.level.demoDone = true;
        }
        //Add force to ball in direction the camera is facing
        rbBall.AddForce(shootDirection.normalized * force, ForceMode.Force);
    }


    //Check if the ball has stopped moving
    void CheckIsStationary()
    {
        if(rbBall.velocity == Vector3.zero)
        {
            score.shotsTaken++;
            currentState = BallState.Stopped;
        }
    }
}
