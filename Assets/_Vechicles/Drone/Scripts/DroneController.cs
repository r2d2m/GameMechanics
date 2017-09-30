using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {

    public float thrustInput;
    public float pitchInput;
    public float yawInput;
    public float rollInput;

    public Animator anim;


    void Update()
    {
        thrustInput = Input.GetAxis("Thrust");
        pitchInput = Input.GetAxis("Vertical");
        rollInput = Input.GetAxis("Horizontal");
        yawInput = Input.GetAxis("Yaw");

        anim.SetFloat("Roll", rollInput);
        anim.SetFloat("Pitch", pitchInput);
    }
}
