using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explossionEffect;

    public AudioSource audioSource;

    public float delay = 1f;
    public float radius = 5f;
    public float explossionForce = 5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("Explode", delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider near in colliders)
        {
            Rigidbody rb = near.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explossionForce, transform.position, radius, 1f, ForceMode.Impulse);
            }

            
        }

        // show effect
        Instantiate(explossionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
        Debug.Log("BOOOMMM");
    } 
}
