using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboRIODrivetrain : MonoBehaviour {

    public SwerveDrive script;

    const float wheelBase = 0.8f;
    const float trackBase = 0.8f;
    //float R = Mathf.Sqrt((wheelBase * wheelBase) + (trackBase * trackBase));

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float y = -Input.GetAxis("Forward");
        float x = Input.GetAxis("Strafe");
        float t = Input.GetAxis("Turn");

        deadband(ref y);
        deadband(ref x);
        deadband(ref t);

        float A = x - t * (wheelBase / trackBase);
        float B = x + t * (wheelBase / trackBase);
        float C = y - t * (trackBase / wheelBase);
        float D = y + t * (trackBase / wheelBase);

        float ws1 = Mathf.Sqrt(Mathf.Pow(B, 2) + Mathf.Pow(C, 2)); //Front Right
        float ws2 = Mathf.Sqrt(Mathf.Pow(B, 2) + Mathf.Pow(D, 2)); //Front Left
        float ws3 = Mathf.Sqrt(Mathf.Pow(A, 2) + Mathf.Pow(D, 2)); //Rear Left
        float ws4 = Mathf.Sqrt(Mathf.Pow(A, 2) + Mathf.Pow(D, 2)); //Rear Right

        float wa1 = Mathf.Atan2(B, C) * 180 / Mathf.PI; //Front Right
        float wa2 = Mathf.Atan2(B, D) * 180 / Mathf.PI; //Front Left
        float wa3 = Mathf.Atan2(A, D) * 180 / Mathf.PI; //Rear Left
        float wa4 = Mathf.Atan2(A, C) * 180 / Mathf.PI; //Rear Right

        float max = Mathf.Max(new float[] { ws1, ws2, ws3, ws4 });
        if (max > 1)
        {
            ws1 = ws1 / max;
            ws2 = ws2 / max;
            ws3 = ws3 / max;
            ws4 = ws4 / max;
        }

        script.leftBackAngle = wa3;
        script.rightBackAngle = wa4;
        script.leftFrontAngle = wa2;
        script.rightFrontAngle = wa1;

        script.leftBackPower = ws3;
        script.rightBackPower = ws4;
        script.leftFrontPower = ws2;
        script.rightFrontPower = ws1;
    }

    void deadband(ref float value)
    {
        if (Mathf.Abs(value) < 0.05)
            value = 0;
    }
}
