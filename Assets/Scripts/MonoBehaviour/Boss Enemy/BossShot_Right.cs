using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot_Right : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 40.0f;
    public Rigidbody2D shot_rb;
    public GameObject Shot_Effect;
    private GameObject Shot_Effect_Temp;

    private Transform player;
    private Vector2 target;


    void Start()
    {
        shot_rb.velocity = transform.right * speed;
        /*
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        /*
        if(transform.position.x == target.x && transform.position.y == target.y){
            DestroyProjectile();
        }*/
    }

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            
            DestroyProjectile();
            
        }
    }
    
    void DestroyProjectile(){
        Shot_Effect_Temp = Instantiate(Shot_Effect, transform.position, transform.rotation);
        Destroy(Shot_Effect_Temp, 0.8f);
        Destroy(gameObject);
    }


}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class UfoAlienEnemyShot : MonoBehaviour
// {
//     // Start is called before the first frame update
//     public float speed;


//     private Transform player;
//     private Vector2 target;


//     void Start()
//     {
//         player = GameObject.FindGameObjectWithTag("Player_Homing").transform;

//         target = new Vector2(player.position.x, player.position.y);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         speed = 60.0f;
//         Vector3 temp = transform.position;
//         temp.x -= speed * Time.deltaTime;
//         transform.position = temp; 
//         //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

//         if(transform.position.x == target.x && transform.position.y == target.y){
//             DestroyProjectile();
//         }
//     }


    
//     void OnTriggerEnter2D(Collider2D other){
//         if(other.CompareTag("Player_Homing")){
//             DestroyProjectile();
//         }
//     }

//     void DestroyProjectile(){
//         Destroy(gameObject);
//     }  

     
// }
