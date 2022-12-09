using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DavidJalbert;

public class Staminacontroller : MonoBehaviour
{
    [Header("Stamina Main Parameters")]
    public float cartStamina;
    [SerializeField] private float maxStamina = 100f;
    [SerializeField]public bool hasRegenerated = true;
    [SerializeField]public bool CartSprinting = false;
    [SerializeField] public float boostcost;


    [Range(0,50)][SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)] [SerializeField] private float staminaRegen = 0.5f;
    [Header("Stamina Speed Parameteres")]
    [SerializeField] private int slowedRungSeepd = 4;
    [SerializeField] private int normalRunSpeed = 8;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgressUI = null;
    [SerializeField] private CanvasGroup sliderCanvasgroup = null;
    private TinyCarController controllerCustom;
    private TinyCarStandardInput CartInput;

    private void Start()
    {
        controllerCustom = GetComponent<TinyCarController>();
        staminaProgressUI.fillAmount = 1;
    }
    private void Update()
    {
        if(!CartSprinting)
        {
            if(cartStamina<=maxStamina-0.01)
            {
                
                UpdateStamina(1);
                cartStamina += staminaRegen * Time.deltaTime;
               
                if (cartStamina>=maxStamina )
                {
                    //normal Speed
                    
                    controllerCustom.maxSpeedForward = 25f;
                    controllerCustom.setBoostMultiplier(1);
                    
                    sliderCanvasgroup.alpha = 0;
                    hasRegenerated = true;
                }
            }
        }
    }
    public void Sprinting()
    {
        if(hasRegenerated)
        {
            CartSprinting = true;
            cartStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);
            if(cartStamina<=0)
            {
                //slowSpeed
                
                hasRegenerated = false;
                controllerCustom.maxSpeedForward = 10f;
                sliderCanvasgroup.alpha = 0;
            }
            
        }
    }
    void UpdateStamina(int value)
    {
        staminaProgressUI.fillAmount = cartStamina / maxStamina;
        if(value==0)
        {
            sliderCanvasgroup.alpha = 0;
        }
        else
        {
            sliderCanvasgroup.alpha = 1;
        }
    }
    public void rapid()
    {
        if (cartStamina>=(maxStamina*boostcost/maxStamina))
        {
            cartStamina -= boostcost;
            UpdateStamina(1);
        }
    }
    public void changeColor()
    {
        
       

        if (0.7<staminaProgressUI.fillAmount)
        {
            staminaProgressUI.color = Color.green;
        }else if(staminaProgressUI.fillAmount<0.7)
        {
            staminaProgressUI.color = Color.yellow;
        }else if( staminaProgressUI.fillAmount<0.5)
        {
            staminaProgressUI.color = Color.red;
        }
        
            
    }
}
