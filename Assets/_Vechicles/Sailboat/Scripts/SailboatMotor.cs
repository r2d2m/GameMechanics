using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailboatMotor : MonoBehaviour {

    private Rigidbody rb_sailboat;

    public float m_Speed = 5f;
    public float m_TurnSpeed = 2f;
    public float m_SailboatVelocity;
    public float m_MaxAngularVelocity = 30;
    public float m_MaxForwardVelocity = 25;

    public float m_UpwardBouyantForce = 19.6f;

    public SailboatController sail_Input;

    public Vector3 windForce = new Vector3(5f,0,0);
    public Vector3 sailBoatDirection;

    public Transform[] rays = new Transform[2];

    private void Start()
    {
        rb_sailboat = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

        Bouyancy();

        float windFacing = Vector3.Dot(windForce.normalized, gameObject.transform.forward);
        float angle = Mathf.Acos(-windFacing);// * Mathf.Rad2Deg;
        
        rb_sailboat.AddRelativeTorque(0, sail_Input.m_TurnInput * m_TurnSpeed, 0, ForceMode.Acceleration);

        rb_sailboat.angularVelocity = Vector3.ClampMagnitude(rb_sailboat.angularVelocity, m_MaxAngularVelocity);

        m_SailboatVelocity = Vector3.Dot(windForce, gameObject.transform.right);

        rb_sailboat.AddRelativeForce(gameObject.transform.forward * m_SailboatVelocity * m_Speed, ForceMode.Force);

        rb_sailboat.velocity = Vector3.ClampMagnitude(rb_sailboat.velocity, m_MaxForwardVelocity);

    }

    private void Bouyancy()
    {
        if (Physics.Raycast(rays[0].position, Vector3.down, .5f))
        {
            Debug.Log("Hitting Water Left");
            rb_sailboat.AddForceAtPosition(Vector3.up * m_UpwardBouyantForce, rays[0].position);
        }
        if (Physics.Raycast(rays[1].position, Vector3.down, .5f))
        {
            Debug.Log("Hitting Water Right");
            rb_sailboat.AddForceAtPosition(Vector3.up * m_UpwardBouyantForce, rays[0].position);
        }
    }
}
