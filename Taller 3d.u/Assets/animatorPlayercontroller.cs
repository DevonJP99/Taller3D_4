using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorPlayercontroller : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Animator animator;

    private void Update()
    {
        animator.SetFloat("Blend", rigidbody.velocity.magnitude/25);
    }

}
