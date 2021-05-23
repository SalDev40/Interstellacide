using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject Shot_Effect;
    private GameObject Shot_Effect_Temp;


    public Sprite upgradedBullet;
    public int cuPoints;
    private const int pointsGoal = 3;
    

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(this.gameObject, 5);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Shot_Effect_Temp = Instantiate(Shot_Effect, transform.position, transform.rotation);
            Destroy(Shot_Effect_Temp, 0.8f);
        
            Destroy(this.gameObject, .01f);
        }
    }
}
