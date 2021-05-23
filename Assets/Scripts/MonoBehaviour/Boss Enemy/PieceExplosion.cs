using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceExplosion : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    float dirY;
    float torque;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        dirX = Random.Range(-100, 100);
        dirY = Random.Range(-30, 80);
        torque = Random.Range(55, 65);
        rb = GetComponent<Rigidbody2D> ();
        Debug.Log(rb);

        rb.AddForce(new Vector2 (dirX, dirY), ForceMode2D.Impulse);
        rb.AddForce(Physics.gravity, ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Force);
        Destroy(gameObject, 2f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
