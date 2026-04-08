using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Transform respawnPoint;
     public bool canLaunch;
    [SerializeField] private float contador = 0;
    [SerializeField] private float startTime;
    
    [Header("Camera Settings")]
    public float mouseSensitivity = 13f;
    [SerializeField] private float smoothing = 60f;

    [Header("Input System")]
    [SerializeField] private InputActionReference InputSystem_Actions;
    public Vector2 currentMouseLook = Vector2.zero;
    
    
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
        Vector2 mouseDelta = InputSystem_Actions.action.ReadValue<Vector2>();
        currentMouseLook.x += mouseDelta.x * mouseSensitivity * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, currentMouseLook.x, 0f);   
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

    public void OnLook()
    {
       
    }
}
