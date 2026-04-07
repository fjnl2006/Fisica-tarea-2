using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ejercicio6 : MonoBehaviour
{
    Rigidbody rb;

    private Vector2 input;

    private bool moving;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(input.x, 0, input.y) * 5, ForceMode.Acceleration);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input =  context.ReadValue<Vector2>();
        if (context.performed)
        {
            moving = true;
        }
        else if  (context.canceled)
        {
            moving = false;
        }
    }
}
