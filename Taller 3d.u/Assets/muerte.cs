using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muerte : MonoBehaviour
{
    public PlayerStaticVariable player;
    public CompradorStateManager manager;
    float force = 25;
    public bool choco = false;
    public Collider[] colliders;
    public Rigidbody[] rigidbodies;
    public Animator animator;

    private void Start()
    {

    }

    private void Update()
    {
        player = GameObject.Find("Cart Controller").GetComponent<PlayerStaticVariable>();
        manager = GetComponent<CompradorStateManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cart Controller") && MejorasStatic.sprint==true)
        {
            foreach (Collider collider in colliders)
            {
                collider.enabled = true;
            }
            foreach (Rigidbody rigidbody in rigidbodies)
            {
                rigidbody.isKinematic = false;
            }
            animator.enabled = false;
            choco = true;
            manager.enabled = false;
            GetComponent<Rigidbody>().AddForce((transform.position - player.transform.position).normalized * force + Vector3.up * force, ForceMode.Impulse);
        }
    }
}
