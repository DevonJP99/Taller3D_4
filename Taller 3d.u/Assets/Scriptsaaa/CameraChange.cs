using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject thirdPersonCam;
    public GameObject combatCam;
    public Transform combatLookAt;
    public enum CameraStyle
    {
        
        Combat,
        Topdown
    }
}
