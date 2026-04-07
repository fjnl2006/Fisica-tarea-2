using UnityEngine;
using UnityEngine.InputSystem;

public class ExplosionController : MonoBehaviour
{

    [Header("Explosion Settings")]
    public float explosionForce = 500f;

    public float explosionRadius = 5f;

    public float upwardsModifier = 2f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnExplosion(InputAction.CallbackContext context)
    {
        
            Debug.Log("explotado");
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                Rigidbody rb = colliders[i].gameObject.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardsModifier);    
                }
                
            }
                
        
        
    }
}
