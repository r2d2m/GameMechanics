using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Motor : MonoBehaviour {

    private BB8Controller BB8Controller;
    private Rigidbody BB8Rigidbody;
    private Transform Body;

    private float oldXaxisDistance;
    private float currentXaxisDistance;
    private float travelledXaxisDistance;
    private float xAxisAngle;

    private float oldZaxisDistance;
    private float currentZaxisDistance;
    private float travelledZaxisDistance;
    private float zAxisAngle;

    public float movementSpeed;

    void Start()
    { 
        BB8Controller = GetComponent<BB8Controller>();
        Body = transform.GetChild(0).GetComponent<Transform>();
    }

    void Update () {


        oldXaxisDistance = gameObject.transform.position.x;
        oldZaxisDistance = gameObject.transform.position.z;
                
        gameObject.transform.position += transform.TransformDirection(BB8Controller.movementInput) * Time.deltaTime * movementSpeed;

        currentXaxisDistance = gameObject.transform.position.x;
        currentZaxisDistance = gameObject.transform.position.z;

        travelledXaxisDistance = currentXaxisDistance - oldXaxisDistance;
        travelledZaxisDistance = currentZaxisDistance - oldZaxisDistance;

        xAxisAngle = (travelledXaxisDistance * 360) / (2 * Mathf.PI * .656f);
        zAxisAngle = (travelledZaxisDistance * 360) / (2 * Mathf.PI * .656f);
        
        Body.Rotate(zAxisAngle, 0, -xAxisAngle, Space.World);
        
	}
}
