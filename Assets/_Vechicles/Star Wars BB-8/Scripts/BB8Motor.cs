using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Motor : MonoBehaviour {

    private BB8Controller BB8Controller;
    private Rigidbody BB8Rigidbody;
    private Transform Body;
    public Transform HeadPivot;
    public Transform Head;

    private float oldXaxisDistance;
    private float currentXaxisDistance;
    private float travelledXaxisDistance;
    private float xAxisAngle;

    private float oldZaxisDistance;
    private float currentZaxisDistance;
    private float travelledZaxisDistance;
    private float zAxisAngle;

    private float angleToRotate;

    public float movementSpeed;

    void Start()
    { 
        BB8Controller = GetComponent<BB8Controller>();
        Body = transform.GetChild(0).GetComponent<Transform>();
    }

    void Update () {


        oldXaxisDistance = gameObject.transform.position.x;
        oldZaxisDistance = gameObject.transform.position.z;

        Vector3 cameraFowardMovementInput = Camera.main.transform.rotation * BB8Controller.movementInput;

        if (BB8Controller.movementInput.magnitude != 0)
        {
            gameObject.transform.position +=  cameraFowardMovementInput * Time.deltaTime * movementSpeed;

            gameObject.transform.forward = Vector3.Lerp(gameObject.transform.forward ,Camera.main.transform.rotation *  BB8Controller.movementInput, Time.deltaTime *5);

            Head.transform.localEulerAngles = Vector3.Lerp(Head.transform.localEulerAngles, new Vector3(0, Camera.main.transform.eulerAngles.y, 0),Time.deltaTime * 10);
        }

       

        float angle = Mathf.Lerp(0, 15, cameraFowardMovementInput.magnitude);

        HeadPivot.rotation = Quaternion.AngleAxis(angle, new Vector3(-cameraFowardMovementInput.z, 0, cameraFowardMovementInput.x));

        currentXaxisDistance = gameObject.transform.position.x;
        currentZaxisDistance = gameObject.transform.position.z;

        travelledXaxisDistance = currentXaxisDistance - oldXaxisDistance;
        travelledZaxisDistance = currentZaxisDistance - oldZaxisDistance;

        xAxisAngle = (travelledXaxisDistance * 360) / (2 * Mathf.PI * .656f);
        zAxisAngle = (travelledZaxisDistance * 360) / (2 * Mathf.PI * .656f);
        
        Body.Rotate(zAxisAngle, 0, -xAxisAngle, Space.World);
        
	}


}
