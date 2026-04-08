using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Transform respawnPoint;
     public bool canLaunch;
    [SerializeField] private float contador = 0;
    [SerializeField] private float startTime;

    public static BallLauncher Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLaunch(InputAction.CallbackContext context)
    {
        if (context.started && canLaunch)
        {
            startTime = Time.time;
            
            

        }
        if (context.canceled && canLaunch)
        { 
            contador = Time.time - startTime;
            contador = contador * 7;
            contador = Mathf.Min(contador, 50);
            Debug.Log(contador);
            rb.AddForce(transform.forward * contador , ForceMode.Impulse);
            
            canLaunch = false;
        }
    }
}
