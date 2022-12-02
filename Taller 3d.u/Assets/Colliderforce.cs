using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliderforce : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cart Controller"))
        {
            rb.AddForce(-transform.forward * force, ForceMode.Impulse);
        }
        
        
    }
}
