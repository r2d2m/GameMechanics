using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Motor : MonoBehaviour {

    private BB8Controller BB8Controller;
    private Rigidbody BB8Rigidbody;
    private Transform Body;
    private Transform Head;

    public float movementSpeed;
    void Start()
    { 
        BB8Controller = GetComponent<BB8Controller>();
        Body = transform.GetChild(0).GetComponent<Transform>();
        Head = transform.GetChild(1).GetComponent<Transform>();
    }

    void Update () {
        gameObject.transform.position += transform.TransformDirection(BB8Controller.movementInput) * Time.deltaTime * movementSpeed;

        Body.Rotate(new Vector3(BB8Controller.movementInput.z, 0 , -BB8Controller.movementInput.x), movementSpeed , Space.World);
        
	}
}
