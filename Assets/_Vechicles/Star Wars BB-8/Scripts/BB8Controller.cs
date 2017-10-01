using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Controller : MonoBehaviour {

    public Vector3 movementInput;
    public Vector3 lookinput;
    public Animator anim;

	void Update () {

        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        lookinput = new Vector3(0,Input.GetAxis("Yaw"),0);

    }
}
