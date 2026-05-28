using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public GameObject coin;
    public float spawnTime = 4f;
    public Transform[] spawnPoints;


    void Start()
    {
        InvokeRepeating("Spawner", spawnTime, spawnTime);
    }


    void Spawner()
    {

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(coin, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        //Destroy(coin, 6.0f);
    }
}
