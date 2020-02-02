using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float speed;
    public Transform[] waypoint;
    private AudioSource DeathSound;
    public ScoreHandler score;
    // Start is called before the first frame update

    void Start()
    {
        DeathSound = GetComponent<AudioSource>();
        speed = Random.Range(1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint[0].position, speed * Time.deltaTime);  
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            DeathSound.Play(0); // Not working to fix doesnt work because object is destroyed and he no liky
            score.addPoints(100);
            Destroy(this);
            Destroy(gameObject, 1.2f);
        }
    }
}
