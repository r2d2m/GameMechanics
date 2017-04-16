using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChopperController : MonoBehaviour {

    public float m_ThrustInput;
    public float m_TorqueInput;
    public float m_Pitch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.LeftShift))
            m_ThrustInput = 1;
        else if (Input.GetKey(KeyCode.LeftControl))
            m_ThrustInput = -1;
        else
            m_ThrustInput = 0;

        m_TorqueInput = Input.GetAxis("Horizontal");

        m_Pitch = Input.GetAxis("Vertical");
	}
}
