using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{

    [SerializeField]
    private BallMovementScript ball;

    [SerializeField]
    private Slider powerBar;


    void Start()
    {
        powerBar.minValue = 0f;
        powerBar.maxValue = ball.maxForce;
        powerBar.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Set the power bar value to the force value
        powerBar.value = ball.force;

        //Change slider colour
        powerBar.image.color = Color.Lerp(Color.red, Color.green, powerBar.value / powerBar.maxValue);

    }
}
