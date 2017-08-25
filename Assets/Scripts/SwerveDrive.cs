using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveDrive : MonoBehaviour {

    public float leftBackAngle;
    public float rightBackAngle;
    public float leftFrontAngle;
    public float rightFrontAngle;

    public float leftBackPower;
    public float rightBackPower;
    public float leftFrontPower;
    public float rightFrontPower;

    WheelCollider backLeft;
    WheelCollider backRight;
    WheelCollider frontLeft;
    WheelCollider frontRight;

    public float power = 500;

	// Use this for initialization
	void Start () {
        backLeft = transform.GetChild(0).GetComponent<WheelCollider>();
        backRight = transform.GetChild(1).GetComponent<WheelCollider>();
        frontLeft = transform.GetChild(2).GetComponent<WheelCollider>();
        frontRight = transform.GetChild(3).GetComponent<WheelCollider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        backLeft.motorTorque = leftBackPower * power;
        backRight.motorTorque = rightBackPower * power;
        frontLeft.motorTorque = leftFrontPower * power;
        frontRight.motorTorque = rightFrontPower * power;

        if (leftBackPower < 0.05)
        {
            backLeft.motorTorque = 0;
            backLeft.brakeTorque = 0.1f;
        }
        else
        {
            backLeft.brakeTorque = 0;
        }
        if (leftFrontPower < 0.05)
        {
            frontLeft.motorTorque = 0;
            frontLeft.brakeTorque = 0.1f;
        }
        else
        {
            frontLeft.brakeTorque = 0;
        }
        if (rightBackPower < 0.05)
        {
            backRight.motorTorque = 0;
            backRight.brakeTorque = 0.1f;
        }
        else
        {
            backRight.brakeTorque = 0;
        }
        if (rightFrontPower < 0.05)
        {
            frontRight.motorTorque = 0;
            frontRight.brakeTorque = 0.1f;
        }
        else
        {
            frontRight.brakeTorque = 0;
        }


        backLeft.steerAngle = leftBackAngle;
        backRight.steerAngle = rightBackAngle;
        frontLeft.steerAngle = leftFrontAngle;
        frontRight.steerAngle = rightFrontAngle;

        //transform.GetChild(0).rotation = Quaternion.Euler(0, leftBackAngle, 0);
        //transform.GetChild(1).rotation = Quaternion.Euler(0, rightBackAngle, 0);
        //transform.GetChild(2).rotation = Quaternion.Euler(0, leftFrontAngle, 0);
        //transform.GetChild(3).rotation = Quaternion.Euler(0, rightFrontAngle, 0);
    }
}
