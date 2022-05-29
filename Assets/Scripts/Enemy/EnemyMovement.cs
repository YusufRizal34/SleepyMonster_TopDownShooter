using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    bool attackPlayer = false;

    private void Awake ()
    {
        //cari player dengan tag "Player"
        player = GameObject.FindGameObjectWithTag ("Player").transform;

        //ambil komponen player
        playerHealth = player.GetComponent <PlayerHealth> ();
        enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }

    void Update ()
    {
        //pindahin posisi player
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && nav.remainingDistance > nav.stoppingDistance)
        {
            nav.updateRotation = true;
            nav.SetDestination(player.position);
        }
        else if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0 && nav.remainingDistance < nav.stoppingDistance){
            nav.updateRotation = false;
            // transform.LookAt(player);
            Vector3 relativePos = player.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 120);
        }
        else //hentikan moving
        {
            nav.enabled = false;
        }
    }
}
