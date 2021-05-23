using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletRedB : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public Rigidbody2D shot_rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        // shot_rb.velocity = transform.right * -speed;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (transform.position.x == player.position.x && transform.position.y == player.position.y)
        {
            DestroybulletRedB();
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroybulletRedB();
        }
    }

    void DestroybulletRedB()
    {
        Destroy(gameObject);

    }
}
