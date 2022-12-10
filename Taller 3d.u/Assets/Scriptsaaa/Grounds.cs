using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DavidJalbert;

public class Grounds : MonoBehaviour
{
    TinyCarSurface surface;
    public GameObject piso;
    // Start is called before the first frame update
    void Start()
    {
        piso.GetComponent<TinyCarSurface>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Pesao();
    }
    public void Pesao()
    {
        if(MejorasStatic.pesado==true)
        {
            surface.parameters.steeringMultiplier = 0.5f;
            surface.parameters.speedMultiplier = 0.5f;
            surface.parameters.accelerationMultiplier = 0.5f;
            surface.parameters.forwardFrictionMultiplier = 1f;
            surface.parameters.lateralFrictionMultiplier = 1f;
            surface.parameters.sideFrictionMultiplier = 1f;
        }else if(MejorasStatic.pesado==false)
        {
            surface.parameters.steeringMultiplier = 1f;
            surface.parameters.speedMultiplier = 1f;
            surface.parameters.accelerationMultiplier = 1f;
            surface.parameters.forwardFrictionMultiplier = 1f;
            surface.parameters.lateralFrictionMultiplier = 1f;
            surface.parameters.sideFrictionMultiplier = 1f;
        }
    }
}
