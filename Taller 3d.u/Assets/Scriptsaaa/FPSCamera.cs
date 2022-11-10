using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera thirdPersonCam;
    [SerializeField] CinemachineVirtualCamera FpsPersonCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        CameraSwitcher.Register(thirdPersonCam);
        CameraSwitcher.Register(FpsPersonCam);
        CameraSwitcher.SwitchCamera(thirdPersonCam);
    }
    private void OnDisable()
    {
        CameraSwitcher.Unregister(thirdPersonCam);
        CameraSwitcher.Unregister(FpsPersonCam);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(CameraSwitcher.IsActiveCamera(thirdPersonCam))
            {
                CameraSwitcher.SwitchCamera(FpsPersonCam);
            }else if(CameraSwitcher.IsActiveCamera(FpsPersonCam))
            {
                CameraSwitcher.SwitchCamera(thirdPersonCam); 
            }
        }
    }
}
