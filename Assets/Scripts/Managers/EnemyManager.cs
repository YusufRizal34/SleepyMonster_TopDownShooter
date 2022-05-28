using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    public int totalEnemies;
    public int currentEnemies;

    public GameObject wall;

    float timer;

    [SerializeField] MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Spawn ()
    {
        //kalo player mati, stop buat enemy
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        currentEnemies++;

        //buat nilai random
        int spawnPointIndex = Random.Range (0, spawnPoints.Length);
        int spawnEnemy = Random.Range(0, 3);

        //duplikat enemy
        Factory.FactoryMethod(spawnEnemy, spawnPoints[spawnPointIndex]);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnTime && currentEnemies < totalEnemies)
        {
            Spawn();
            spawnTime *= 0.99f;
            timer = 0;
        }


        if (currentEnemies >= totalEnemies)
        {
            Destroy(wall);
        }
    }
}
