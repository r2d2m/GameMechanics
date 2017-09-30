using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Controller : MonoBehaviour {

    public Vector3 movementInput;
    public Animator anim;

	void Update () {
        movementInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        anim.SetFloat("Horizontal",movementInput.x);
        anim.SetFloat("Vertical", movementInput.z);
	}
}
