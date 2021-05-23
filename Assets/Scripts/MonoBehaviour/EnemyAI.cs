using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;        

public class EnemyAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;        
    public float retreatDistance;
    public float maxHitPoints;
    public int deathPoints = 0;

    public bool canShoot;
    public float fireRate = 0.5f;

    private float nextFire = 0.0f;
    
    public GameObject enemyBullet;
    private Confiner levelEnemies;        
    public Transform player;
    public Transform firePoint; 


    void Start()
    {
        GameObject Enes = GameObject.FindGameObjectWithTag("Player"); 
        player = Enes.transform; 

        
            
        //get number of enemies in level
        GameObject PlayerConfiner = GameObject.Find("PlayerConfiner");
        levelEnemies = PlayerConfiner.GetComponent<Confiner>();       
    }

    void Update()
    {
        GameObject isAliveEnes = GameObject.FindGameObjectWithTag("Player");
        //check if enes is alive, if he is continue AI, else print hes dead
        if (isAliveEnes == null)
        {
            Debug.Log("Enes is Dead rip...");
        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(transform.position, player.position) >
             stoppingDistance && Vector2.Distance(transform.position, player.position)
              > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) >
            retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

            if (canShoot && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(enemyBullet, firePoint.position,firePoint.rotation);
                }

        }



    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                DecreaseHitPoints(1f);

            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                DecreaseHitPoints(0.5f);

            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                DecreaseHitPoints(0.5f);
            }
        }

    }
    public void DecreaseHitPoints(float amount)
    {

        maxHitPoints = maxHitPoints - amount;


        if (maxHitPoints <= deathPoints)
        {
            //increment counter of how many enemies dead in the level

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                    levelEnemies.firstLevelEnemiesDead += 1 ;
                    Debug.Log("FIRST LEVEL ENEMIES DEAD: " +
                    levelEnemies.firstLevelEnemiesDead);

            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                    levelEnemies.secondLevelEnemiesDead += 1 ;
                    Debug.Log("SECOND LEVEL ENEMIES DEAD: " +
                    levelEnemies.secondLevelEnemiesDead);

            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                    levelEnemies.thirdLevelEnemiesDead += 1 ;
                    Debug.Log("THIRD LEVEL ENEMIES DEAD: " + 
                    levelEnemies.thirdLevelEnemiesDead);
            }
            Destroy(gameObject, .01f);
            GameScore.RegularUFOsKilled++;
            Debug.Log("Regular UFOs killed: " + GameScore.RegularUFOsKilled);
        }
    }

}
