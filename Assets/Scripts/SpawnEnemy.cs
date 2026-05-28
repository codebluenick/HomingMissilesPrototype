using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;


    void Start()
    {
        InvokeRepeating("Spawner", spawnTime, spawnTime);
    }


    void Spawner()
    {


        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        var newObject = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        newObject.transform.parent = gameObject.transform;


        //Destroy(enemy, 8.0f);
    }
}
