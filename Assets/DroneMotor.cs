using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneMotor : MonoBehaviour
{

    private DroneController DroneController;

    public float forwardSpeed;
    public float strafeSpeed;
    public float thrustSpeed;
    public float turnSpeed;


    void Start()
    {
        DroneController = GetComponent<DroneController>();
    }


    void Update()
    {
        
        gameObject.transform.position += transform.TransformDirection(DroneController.rollInput * strafeSpeed, DroneController.thrustInput * thrustSpeed, DroneController.pitchInput * forwardSpeed);
        gameObject.transform.rotation *= Quaternion.AngleAxis( DroneController.yawInput * 25 * turnSpeed, Vector3.up);

    }
}