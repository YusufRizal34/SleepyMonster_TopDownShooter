using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public float range = 100f;

    Animator anim;
    public GameObject player;
    public PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;

    public Transform spawnPoint;
    public GameObject grenade;

    void Awake ()
    {
        //cari player
        player = GameObject.FindGameObjectWithTag ("Player");

        //ambil komponen health si player
        playerHealth = player.GetComponent <PlayerHealth> ();

        //ambil komponen health enemy
        enemyHealth = GetComponent<EnemyHealth>();

        //ambil komponen animator
        anim = GetComponent <Animator> ();
    }

    void OnTriggerEnter (Collider other)
    {
        //set player dalam range
        if(other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;
        }
    }

    //callback jika ada objek keluar dari trigger
    void OnTriggerExit (Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update ()
    {
        timer += Time.deltaTime;

        //trigger animasi dead klo darah player habis
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger ("PlayerDead");
        }
    }

    private void LateUpdate() {
        if(timer >= timeBetweenAttacks && playerInRange 
            && enemyHealth.currentHealth > 0)
        {
            Attack();
        }
    }

    void Attack ()
    {
        //reset timer
        timer = 0f;

        GameObject grenadeInstance = Instantiate(grenade, spawnPoint.position, spawnPoint.rotation);
        grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * range, ForceMode.Impulse);
    }
}
