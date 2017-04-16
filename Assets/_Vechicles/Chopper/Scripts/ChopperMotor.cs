using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopperMotor : MonoBehaviour {

    public ChopperController chopperInput;

    public float m_UpthrustForce = 5f;
    public float m_ForwardThrust = 1f;
    public float m_TurnSpeed = 0.5f;
    public float m_MaxPitch = 15;
    

    private Rigidbody chopper;
    
    // Use this for initialization
	void Start () {
        chopper = GetComponent<Rigidbody>();
        chopperInput = GetComponent<ChopperController>();
	}

    private void FixedUpdate()
    {
        //Pitch the chopper's transform
        chopper.transform.localEulerAngles = new Vector3(-chopperInput.m_Pitch * m_MaxPitch, chopper.transform.localEulerAngles.y, 0);

        //Forward thrust
        if (chopperInput.m_Pitch > 0)
        {
            chopper.AddRelativeForce(transform.worldToLocalMatrix.MultiplyVector(-1 * transform.forward) * chopperInput.m_ThrustInput * m_ForwardThrust, ForceMode.Acceleration);
        }
        //Backwards thrust
        else if (chopperInput.m_Pitch < 0)
        {
            chopper.AddRelativeForce(transform.worldToLocalMatrix.MultiplyVector(transform.forward) * chopperInput.m_ThrustInput * m_ForwardThrust, ForceMode.Acceleration);
        }
        //Up and Down thrust
        else if (chopperInput.m_Pitch == 0)
            chopper.AddRelativeForce(transform.worldToLocalMatrix.MultiplyVector(Vector3.up) * chopperInput.m_ThrustInput * m_UpthrustForce, ForceMode.Acceleration);

        //Chopper yaw
        chopper.AddRelativeTorque(0, chopperInput.m_TorqueInput * m_TurnSpeed, 0, ForceMode.Acceleration);

        //Limit velocity
        chopper.velocity = Vector3.ClampMagnitude(chopper.velocity, 5);

        //Limit angular velocity
        chopper.angularVelocity = Vector3.ClampMagnitude(chopper.angularVelocity, 0.5f);

    }
}
