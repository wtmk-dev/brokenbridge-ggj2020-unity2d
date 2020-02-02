using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
public class PlayerInputHandler : MonoBehaviour
{
    private float positive = 1f;
    private float negative = -1f;
    private Movement movement;


    void Awake()
    {
        movement = GetComponent<Movement>();    
    }

    public void OnHorizontal(InputValue value)
    {   
        if(movement == null)
        {
            return;
        }

        var horizontalInput = value.Get<float>();
        movement.Horizontal = horizontalInput;
    }

    public void OnVertical(InputValue value)
    {   
        if(movement == null)
        {
            return;
        }

        var verticalInput = value.Get<float>();
        movement.Vertical = verticalInput;
    }
}
