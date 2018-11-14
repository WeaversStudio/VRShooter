﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public bool enableMovement = true; //allow player to move and rotate
    public bool enableRotation = true; //
    [Space(10)]
    public Transform playerHead;
    public Transform playerBody;

    private Vector3 movementVector; //the vector the player is moving
    private Vector3 headAngle; //the angle the player is looking
    private Vector3 bodyAngle; //the angle the player is looking

    void Update()
    {
        if (enableMovement) //check if controls are enabled
        {
            ControlMovement(); //control players movement
        }

        if (enableRotation)
        {
            ControlRotation(); //control players rotation
        }
    }

    void ControlMovement() //gets movement input and applies it
    {
        Vector2 movementInput = GetMovementInput(); //get movement input
        ApplyMovementInput(movementInput); //apply movement input
    }

    public Vector2 GetMovementInput() //gets movement input
    {
        float movementInput_x = 0f; //clear movement inputs for new assignment
        float movementInput_y = 0f; //

        if (inputManager.detection_joystickController) //check if a joypad is connected
        {
            movementInput_x = Input.GetAxis("Left Stick X Axis"); //set the movement inputs to the controller's left stick axis values
            movementInput_y = Input.GetAxis("Left Stick Y Axis"); //
        }
        else
        {
            if (Input.GetKey("d")) { movementInput_x = 1; } else if (Input.GetKey("a")) { movementInput_x = -1; } //set the movement inputs to the keyboard's WASD input values
            if (Input.GetKey("w")) { movementInput_y = 1; } else if (Input.GetKey("s")) { movementInput_y = -1; } //
        }

        Vector2 movementInput = new Vector2(movementInput_x, movementInput_y); //store the movement inputs in a vector
        return movementInput; //return the movement input
    }

    void ApplyMovementInput(Vector2 movementInput) //applies movement input
    {
        Quaternion playerDirection = Quaternion.Euler(0f, playerBody.eulerAngles.y, 0f); //find what direction the player is facing
        movementVector = playerDirection * new Vector3(movementInput.x, 0f, movementInput.y); //set the vector the player will move in
        Vector3.ClampMagnitude(movementVector, 1f); //clamp vector magnitude so movement is never faster than 1

        transform.position += movementVector / 50f; //apply movement vector to the player's position
    }


    void ControlRotation() //gets rotation input and applies it
    {
        Vector2 rotationInput = GetRotationInput(); //get rotation input
        ApplyRotationInput(rotationInput); //apply rotation input
    }

    public Vector2 GetRotationInput() //gets rotation input
    {
        float rotationInput_x; //clear rotation inputs for new assignment
        float rotationInput_y; //

        if (inputManager.detection_joystickController) //check if joypad is connected
        {
            rotationInput_x = Input.GetAxis("Right Stick X Axis"); //set the rotation inputs to the controller's right stick axis values
            rotationInput_y = Input.GetAxis("Right Stick Y Axis"); //
        }
        else
        {
            rotationInput_x = Input.GetAxis("Mouse X"); //set the movement inputs to the mouse's axis values
            rotationInput_y = Input.GetAxis("Mouse Y"); //
        }

        Vector2 rotationInput = new Vector2(rotationInput_x, rotationInput_y); //store the rotation inputs in a vector
        return rotationInput; //return the rotation input
    }

    void ApplyRotationInput(Vector2 rotationInput) //applies movement input
    {
        bodyAngle += new Vector3(0f, rotationInput.x, 0f);  //add rotation input
        headAngle += new Vector3(rotationInput.y, 0f, 0f);  //add rotation input

        if (inputManager.detection_VRHeadset) //check if VR headset is connected
        {
            headAngle.x = Mathf.Clamp(headAngle.x, 0f, 0f); //clamp rotation axis x to 0 (locks up and down inputs to not effect rotation)
        }

        playerBody.localEulerAngles = bodyAngle;
        playerHead.localEulerAngles = headAngle; //set player head's rotation to the new angle
    }
}