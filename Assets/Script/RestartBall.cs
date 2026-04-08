using System;
using UnityEngine;

public class RestartBall : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawnPoint.position;
            other.transform.rotation = new Quaternion(0, 0, 0, 0);
            other.gameObject.GetComponent<Rigidbody>().angularVelocity =Vector3.zero;
            other.gameObject.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        }
    }
}
