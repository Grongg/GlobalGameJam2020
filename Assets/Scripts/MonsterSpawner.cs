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
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        spawnSpeed = 3f;
        spawnAllowed = true;
        time = Time.time;
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
        if (spawnAllowed && Time.time - time < 30)
        {
            spawnAllowed = false;
            Invoke("SpawnMonster", spawnSpeed);
            if (spawnSpeed > 0.3f)
                spawnSpeed -= 0.1f;
        }
        if (Time.time - time > 35)
        {
            Debug.Log("Hehehe....");
            time = Time.time;
        }
    }
}
