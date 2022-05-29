using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject explossionEffect;

    public AudioSource audioSource;

    public float delay = 1f;
    public float radius = 5f;
    public float explossionForce = 2f;
    public int damage = 20;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
