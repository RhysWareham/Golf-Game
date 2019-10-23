using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckLockButton : MonoBehaviour {

    [SerializeField]
    private BallMovementScript ball;

    [SerializeField]
    private Button lockButton;




    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lockButton.GetComponent<Button>().onClick.AddListener(() => ButtonClicked(1));
    }

    //If lock button has been clicked, set the current state to AddForce

    void ButtonClicked(int buttonNo)
    {
        ball.currentState = BallMovementScript.BallState.ChangePower;

    }
}
