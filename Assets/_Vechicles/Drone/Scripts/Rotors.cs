using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotors : MonoBehaviour {
    
    public Transform[] rotorBlades = new Transform[4];
    public float rotorSpeed;
    void Update()
    {
        for (int i = 0; i < rotorBlades.Length; i++)
        {
            rotorBlades[i].eulerAngles += Vector3.forward * rotorSpeed;
        }
    }
}
