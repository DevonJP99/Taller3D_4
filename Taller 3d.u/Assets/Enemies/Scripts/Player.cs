using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life = 100;
    //donde 0 es vacio y 1 es completamente lleno
    [Range(0,1)]
    public float espacioCarrito = 1;
    CharacterController controller;
    [SerializeField]
    Transform cam;
    Vector3 playerVelocity;
    bool groundedPlayer;
    float playerSpeed = 10.0f;
    float jumpHeight = 1.0f;
    float gravityValue = -9.81f;
    float mouseSensitivity = 3;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {

        cam.transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"),0) * mouseSensitivity;
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = cam.forward * move.z + cam.right * move.x;
        controller.Move(move * Time.deltaTime * playerSpeed);


        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
