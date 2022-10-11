using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarritoMove : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardAccel = 8f;
    public float reversarlAccel = 4f;
    public float maxSpeed = 50f;
    public float turnStrength = 180;
    public float gravityforce=10f;
    public float dragGround = 3f;
    private bool grounded;
    public LayerMask whatisGround;
    public float groundRayLength = 0.5f;
    public Transform GrounRayPoint;
    private float speedInput, turnInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if(Input.GetAxis("Vertical")>0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel*5f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reversarlAccel * 5f;
        }
        turnInput = Input.GetAxis("Horizontal");
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles+new Vector3(0f,turnInput*turnStrength*Time.deltaTime*Input.GetAxis("Vertical"),0f));
        transform.position = rb.transform.position;
       
    }
    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        if(Physics.Raycast(GrounRayPoint.position,-transform.up,out hit,groundRayLength,whatisGround))
        {
            grounded = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        if (grounded)
        {
            rb.drag = dragGround;
            if (Mathf.Abs(speedInput) > 0)
            {
                rb.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            rb.drag = 0.1f;
            rb.AddForce(Vector3.up * -gravityforce * 100f);
        }
    }
}
