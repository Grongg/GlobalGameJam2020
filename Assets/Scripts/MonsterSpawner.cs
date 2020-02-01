using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] monsters;
    int rdmSpawn, rdmMonster;
    float spawnSpeed;
    public static bool spawnAllowed;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpeed = 1f;
        spawnAllowed = true;
    }

    void SpawnMonster()
    {
        rdmSpawn = Random.Range(0, spawnPoints.Length);            
        rdmMonster = Random.Range(0, monsters.Length);
        Instantiate(monsters[rdmMonster], spawnPoints[rdmSpawn].position, Quaternion.identity);
        spawnAllowed = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnAllowed)
        {
            spawnAllowed = false;
            Invoke("SpawnMonster", spawnSpeed);
            if (spawnSpeed > 1.0f)
                spawnSpeed -= 1f;
        }
    }
}
