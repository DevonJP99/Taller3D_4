using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GameAudioScriptingEssentials;

namespace DavidJalbert
{
    public class TinyCarStandardInput : MonoBehaviour
    {
        //public PlayerStaticVariable 
        public TinyCarController carController;
        public Staminacontroller staminaController;
        [SerializeField]
        private bool readyToboost=false;
        public float boostNormal;
        [SerializeField]
        private  bool isSprinting;
        [SerializeField]
        private bool iswalking;
        [SerializeField]
        private bool readyTowalk = false;

        [SerializeField] AudioClipRandomizer footsteps;
        [SerializeField] AudioClipRandomizer sprinteps;

        public enum InputType
        {
            None, Axis, RawAxis, Key, Button
        }

        [System.Serializable]
        public struct InputValue
        {
            [Tooltip("Type of input.")]
            public InputType type;
            [Tooltip("Name of the input entry.")]
            public string name;
            [Tooltip("Returns the negative value when using an axis type.")]
            public bool invert;
        }

        [Header("Input")]
        [Tooltip("Input type to check to make the vehicle move forward.")]
        public InputValue forwardInput = new InputValue() { type = InputType.RawAxis, name = "Vertical", invert = false };
        [Tooltip("Input type to check to make the vehicle move backward.")]
        public InputValue reverseInput = new InputValue() { type = InputType.RawAxis, name = "Vertical", invert = true };
        [Tooltip("Input type to check to make the vehicle turn right.")]
        public InputValue steerRightInput = new InputValue() { type = InputType.RawAxis, name = "Horizontal", invert = false };
        [Tooltip("Input type to check to make the vehicle turn left.")]
        public InputValue steerLeftInput = new InputValue() { type = InputType.RawAxis, name = "Horizontal", invert = true };
        [Tooltip("Input type to check to give the vehicle a speed boost.")]
        public InputValue boostInput = new InputValue() { type = InputType.Key, name = ((int)KeyCode.LeftShift).ToString(), invert = false };
        [Tooltip("For how long the boost should last in seconds.")]
        public float boostDuration = 1;
        [Tooltip("How long to wait after a boost has been used before it can be used again, in seconds.")]
        public float boostCoolOff = 0;
        [Tooltip("The value by which to multiply the speed and acceleration of the car when a boost is used.")]
        public float boostMultiplier = 2;

        private float boostTimer = 0;

        void Start()
        {
            staminaController = GameObject.Find("Cart Controller").GetComponent<Staminacontroller>();
        }

        void Update()
        {
            float motorDelta = getInput(forwardInput) - getInput(reverseInput);
            float steeringDelta = getInput(steerRightInput) - getInput(steerLeftInput);

            /*Input.GetButtonDown("left shift")*/
            /*Input.GetKeyDown(KeyCode.LeftShift)*/
            /*if (getInput(boostInput) == 1 && boostTimer == 0)
            {
                boostTimer = boostCoolOff + boostDuration;

                if (boostTimer > 0)
                {
                    boostTimer = Mathf.Max(boostTimer - Time.deltaTime, 0);
                    carController.setBoostMultiplier(boostTimer > boostCoolOff ? boostMultiplier : 1);
                }
            }*/
            boost();
            if(!readyToboost && isSprinting && !iswalking)
            {
                StartCoroutine(Sprit());
            }
            if(!readyTowalk && iswalking && !isSprinting)
            {
                StartCoroutine(Walk());
            }
            ruidomove();
            carController.setSteering(steeringDelta);
            carController.setMotor(motorDelta);
        }

        public float getInput(InputValue v)
        {
            float value = 0;
            switch (v.type)
            {
                case InputType.Axis: value = Input.GetAxis(v.name); break;
                case InputType.RawAxis: value = Input.GetAxisRaw(v.name); break;
                case InputType.Key: value = Input.GetKey((KeyCode)int.Parse(v.name)) ? 1 : 0; break;
                case InputType.Button: value = Input.GetButton(v.name) ? 1 : 0; break;
            }
            if (v.invert) value *= -1;
            return Mathf.Clamp01(value);
        }
       
        public void boost()
        {
            if (Input.GetKey(KeyCode.LeftShift) && staminaController.cartStamina >= 0 && staminaController.hasRegenerated == true)
            {
                StartCoroutine(Sprit());
                carController.setBoostMultiplier(2);
                staminaController.Sprinting();
                MejorasStatic.sprint = true;
                isSprinting = true;
                iswalking = false;
                
            }
            if(Input.GetKeyUp(KeyCode.LeftShift) || staminaController.cartStamina<=0)
            {
                readyToboost = false;
                MejorasStatic.sprint = false;
                carController.setBoostMultiplier(1);
                staminaController.CartSprinting = false;
                StopCoroutine(Sprit());
                isSprinting = false;
            }
        }
        IEnumerator Sprit()
        {
            readyToboost = true;
            if(isSprinting)
            {
                footsteps.PlaySFX();
                yield return new WaitForSeconds(boostCoolOff/12.0f);

            }
            readyToboost = false;
        }
        IEnumerator Walk()
        {
            readyTowalk = true;
            if(iswalking)
            {
                sprinteps.PlaySFX();
                yield return new WaitForSeconds(boostCoolOff / 12.0f);
            }
            readyTowalk = false;
        }
     public void ruidomove()
        {
            if(Input.GetKey(KeyCode.W))
            {
                iswalking = true;
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                iswalking = false;
            }
            

        }
    }
}