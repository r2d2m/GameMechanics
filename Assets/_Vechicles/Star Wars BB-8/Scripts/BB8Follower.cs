using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Follower : MonoBehaviour {

    public Transform BB8;
    public BB8Controller BB8Controller;
    private Vector3 cameraPosition;


    public float depthOffset;
    public float heightOffset;
    public float pitchAngle;


    void Update()
    {
        gameObject.transform.rotation *= Quaternion.AngleAxis(BB8Controller.lookinput.y, Vector3.up);

        cameraPosition = new Vector3(BB8.position.x + Mathf.Sin(gameObject.transform.eulerAngles.y * Mathf.Deg2Rad) * depthOffset, 
                                     heightOffset, 
                                     BB8.position.z + Mathf.Cos(gameObject.transform.eulerAngles.y * Mathf.Deg2Rad) * depthOffset);

        gameObject.transform.position = cameraPosition;

    }
    
}
