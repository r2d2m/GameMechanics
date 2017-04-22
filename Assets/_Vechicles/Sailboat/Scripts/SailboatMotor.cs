using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SailboatMotor : MonoBehaviour {

    private Rigidbody rb_sailboat;

    //Sailboat physics properties
    public float m_Speed = 5f;
    public float m_TurnSpeed = 2f;
    public float m_SailboatVelocity;
    public float m_MaxAngularVelocity = 30;
    public float m_MaxForwardVelocity = 25;
    public float m_UpwardBouyantForce = 19.6f;

    public SailboatController sail_Input;

    //World wind force
    public Vector3 windForce;

    //variable to manage a complete 360 degree rotation to indicate wind direction on UI sprite
    public bool dirChange;
    //Ray positions for checking if the boat is colliding with water
    public Transform[] rays = new Transform[2];

    //UI for effective boat speed and wind direction
    public Slider speedMeasure;
    public Image windUIImage;

    private void Start()
    {
        rb_sailboat = GetComponent<Rigidbody>();

        speedMeasure.minValue = 0;
        speedMeasure.maxValue = Mathf.Sqrt(windForce.x + windForce.z);
    }

    

    private void FixedUpdate()
    {

        
        //Applies bouyant forces on boat
        Bouyancy();

        //Determine wind facing direction
        float windFacing = Vector3.Dot(windForce.normalized, gameObject.transform.right);
        float dummy = Vector3.Dot(windForce.normalized, gameObject.transform.forward);
        float angle = Mathf.Acos(windFacing) * Mathf.Rad2Deg;
                
        if (dummy < 0)
        {
            dirChange = true;
        }

        if (dummy > 0)
        {
            dirChange = false;
        }

        if (dirChange)
        {
            angle = 360 - angle;
        }

        //Turn sailboat
        rb_sailboat.AddRelativeTorque(0, sail_Input.m_TurnInput * m_TurnSpeed, 0, ForceMode.Force);
        //Limit turn velocity
        rb_sailboat.angularVelocity = Vector3.ClampMagnitude(rb_sailboat.angularVelocity, m_MaxAngularVelocity);
        //Calculate effective velocity of sailboat with respect to wind force
        m_SailboatVelocity = Vector3.Dot(windForce, gameObject.transform.right);
        //Absolute forward effective velocity
        m_SailboatVelocity = Mathf.Abs(m_SailboatVelocity);
        //Sailboat forward force 
        rb_sailboat.AddRelativeForce(transform.worldToLocalMatrix.MultiplyVector(gameObject.transform.forward) * m_SailboatVelocity * m_Speed, ForceMode.Acceleration);
        //Limit max velocity
        rb_sailboat.velocity = Vector3.ClampMagnitude(rb_sailboat.velocity, m_MaxForwardVelocity);

        //UI values for speed and wind direction indicator
        speedMeasure.value = m_SailboatVelocity;
        windUIImage.rectTransform.eulerAngles = new Vector3(0, 0, angle);

    }

    private void Bouyancy()
    {
        if (Physics.Raycast(rays[0].position, Vector3.down, .5f))
        {
            //Debug.Log("Hitting Water Left");
            rb_sailboat.AddForceAtPosition(Vector3.up * m_UpwardBouyantForce, rays[0].position - new Vector3(-.35f,0,0),ForceMode.Force);
        }
        if (Physics.Raycast(rays[1].position, Vector3.down, .5f))
        {
            //Debug.Log("Hitting Water Right");
            rb_sailboat.AddForceAtPosition(Vector3.up * m_UpwardBouyantForce, rays[1].position + new Vector3(.35f, 0, 0),ForceMode.Force);
        }
    }


    /* -----------------------------Debug arrows----------------------------- */
    //Gizmo 3D wind direction arrow 
    public Transform[] rayStartpos;

    private void OnDrawGizmos()
    {
        Vector3 x;
        x.x = windForce.x;
        x.y = windForce.z;
        x.z = 0;

        for (int i = 0; i < rayStartpos.Length; i++)
        {
            Debug.DrawRay(rayStartpos[i].position, x.normalized * 2, Color.red);
            Debug.DrawRay(rayStartpos[i].position + x.normalized * 2, Quaternion.LookRotation(x.normalized) * Quaternion.Euler(180 + 20f, 0, 0) * new Vector3(0, 0, 1) * 0.25f, Color.red);
            Debug.DrawRay(rayStartpos[i].position + x.normalized * 2, Quaternion.LookRotation(x.normalized) * Quaternion.Euler(180 - 20f, 0, 0) * new Vector3(0, 0, 1) * 0.25f, Color.red);
        }
        
    }
}
