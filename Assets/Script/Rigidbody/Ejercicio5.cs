using UnityEngine;
using UnityEngine.InputSystem;


public class Ejercicio5 : MonoBehaviour
{
    Rigidbody rb;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}
