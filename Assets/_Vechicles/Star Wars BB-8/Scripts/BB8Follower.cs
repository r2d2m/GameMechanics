using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB8Follower : MonoBehaviour {

    public Transform BB8;

    void Update()
    {
        gameObject.transform.position = new Vector3(BB8.position.x, BB8.position.y + 2, BB8.position.z - 5);
    }
    
}
