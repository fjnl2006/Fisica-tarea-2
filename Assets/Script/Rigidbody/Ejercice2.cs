using UnityEngine;
using UnityEngine.InputSystem;

public class Ejercice2 : MonoBehaviour
{
    Rigidbody rb;

    public float force;

    private bool ismoving;
    
    private Vector2 input;
    private Vector3 intput;
    
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
            rb.AddForce(intput * force);
            Debug.Log("pulsado");
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        intput = new Vector3(input.x,0 ,input.y);
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
