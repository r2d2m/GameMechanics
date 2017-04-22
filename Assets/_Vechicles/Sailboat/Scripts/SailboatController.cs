using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailboatController : MonoBehaviour {

    public float m_TurnInput;
    public bool isSailing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxis("Vertical") > 0)
            isSailing = true;
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxis("Vertical") < 0)
            isSailing = false;

        m_TurnInput = Input.GetAxis("Horizontal");
    }
}
