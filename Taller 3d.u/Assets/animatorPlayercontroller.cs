using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorPlayercontroller : MonoBehaviour
{
    public GameObject papaAnim, papaRag;

    public Rigidbody rigidbody;
    public Animator animator;

    [SerializeField]
    Rigidbody[] rigds;
    [SerializeField]
    Collider[] colls;

    public bool ragdollStatus = false;

    private void Start()
    {
        ToggleRagDoll(ragdollStatus);

    }

    private void Update()
    {
        animator.SetFloat("Blend", rigidbody.velocity.magnitude / 25);
        if (Input.GetKeyDown(KeyCode.R))
        {
            ToggleRagDoll(!ragdollStatus);
        }
    }


    public void ToggleRagDoll(bool status)
    {
        foreach (Rigidbody rig in rigds)
        {
            rig.isKinematic = !status;
        }

        foreach (Collider col in colls)
        {
            col.enabled = status;
        }
        animator.enabled = !status;

        ragdollStatus = status;

        transform.SetParent(status ? papaRag.transform : papaAnim.transform);
    }
}
