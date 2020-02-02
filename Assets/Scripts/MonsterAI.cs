using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float speed;
    public Transform[] waypoint;
    // Start is called before the first frame update

    void Start()
    {
        speed = Random.Range(1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint[0].position, speed * Time.deltaTime);  
    }
}
