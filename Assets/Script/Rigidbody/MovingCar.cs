using System;
using UnityEngine;
using  UnityEngine.InputSystem;

public class MovingCar : MonoBehaviour
{
    Rigidbody rb;

    public float force;

    private bool ismoving;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        if (ismoving)
        {
            rb.AddForce(Vector3.forward * force);
            Debug.Log("pulsado");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           ismoving = true;
        }

        if (context.canceled)
        {
            ismoving = false;
        }
    }
}
