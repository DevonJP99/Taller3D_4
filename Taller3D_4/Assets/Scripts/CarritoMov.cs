using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoMov : MonoBehaviour
{
    public float Movespeed;
    public float Maxspeed;
    public float Drag = 0.98f;
    public float SteerAngle = 20f;
    public float Traction = 1;
    private Vector3 MoveForce;
    public Transform cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Moving
        MoveForce += transform.forward * Movespeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;
        // Stering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * SteerAngle * Time.deltaTime);

        // Drag and max speed limit
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, Maxspeed);
        // Traction 
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime)*MoveForce.magnitude;
    }
 
}
