using UnityEngine;
using UnityEngine.InputSystem;

public class LookBall : MonoBehaviour
{
    [Header("Camera Settings")] public float mouseSensitivity = 13;
    [SerializeField] private float smoothing = 60f;
    [SerializeField] private bool invertY = false;
    [SerializeField] private float clampAngleX = 40f;
    [SerializeField] private float clampAngleY = 60f;
    [SerializeField] private Transform player;

    [Header("InputSystem")] [SerializeField]
    private InputActionReference InputSystem_Actions;

    public Vector2 currentMouseLook = Vector2.zero;

    private Vector2 appliedMouseDelta = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else if (Time.timeScale == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Vector2 mouseDelta = InputSystem_Actions.action.ReadValue<Vector2>();
            appliedMouseDelta =
                Vector2.Lerp(appliedMouseDelta, mouseDelta, 1f / (Mathf.Max(mouseSensitivity, smoothing)));
            float invertFactor = invertY ? -1f : 1f;
            currentMouseLook.x += appliedMouseDelta.x * mouseSensitivity * Time.deltaTime;
            currentMouseLook.x %= 360f;
            currentMouseLook.y += appliedMouseDelta.y * mouseSensitivity * Time.deltaTime * invertFactor;
            currentMouseLook.y = Mathf.Clamp(currentMouseLook.y, -clampAngleY, clampAngleY);
            transform.localRotation = Quaternion.Euler(-currentMouseLook.y, 0f, 0f);

            Transform body = player != null ? player : transform.parent;
            if (body != null)
            {
                body.localRotation = Quaternion.Euler(0f, currentMouseLook.x, 0f);
                //Debug.Log(currentMouseLook);
            }
        }
    }
}