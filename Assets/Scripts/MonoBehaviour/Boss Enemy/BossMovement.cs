using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMovement : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float maxHitPoints;
    public int deathPoints = 0;
    public GameObject stardustPrefab;


    private Confiner levelEnemies;
    public Transform player;


    // for animations
    public Animator animator;


    // for death animation using prefab and Instantiate
    public GameObject BossDeath;
    private GameObject BossDeath_Temp;
    
    public Vector2 relativePoint;


    public GameObject BossPiece01, BossPiece02, BossPiece03, BossPiece04, BossPiece05, BossPiece06, BossPiece07, BossPiece08, BossPiece09, BossPiece10, BossPiece11, BossPiece12, BossPiece13, BossPiece14, BossPiece15, BossPiece16, BossPiece17, BossPiece18,  BossPiece19;

    public GameObject ParticleBurst;



    // Start is called before the first frame update
    void Start()
    {
        GameObject Enes = GameObject.FindGameObjectWithTag("Player");
        player = Enes.transform;



        //get number of enemies in level
        GameObject PlayerConfiner = GameObject.Find("PlayerConfiner");
        levelEnemies = PlayerConfiner.GetComponent<Confiner>();

    }

    // Update is called once per frame
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
            else if (Vector2.Distance(transform.position, player.position) <
             stoppingDistance && Vector2.Distance(transform.position, player.position)
              > retreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, player.position) <
            retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }

           


        }
       
        
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
           
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
               
                DecreaseHitPoints(0.5f);

            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                DecreaseHitPoints(1f);
            }
        }

    }
    
    public void DecreaseHitPoints(float amount)
    {

        maxHitPoints = maxHitPoints - amount;
        

        if (maxHitPoints <= deathPoints)
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                levelEnemies.secondLevelEnemiesDead += 1;
                Debug.Log("SECOND LEVEL ENEMIES DEAD: " +
                levelEnemies.secondLevelEnemiesDead);

            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                levelEnemies.thirdLevelEnemiesDead += 1;
                Debug.Log("THIRD LEVEL ENEMIES DEAD: " +
                levelEnemies.thirdLevelEnemiesDead);
            }
            // to play death animation for right and left side.
            /*BossDeath_Temp = Instantiate(BossDeath, transform.position, transform.rotation);
            Destroy(BossDeath_Temp, .50f);*/

            //instantiate boss piece explosion
            Instantiate(BossPiece01, transform.position, Quaternion.identity);
            Instantiate(BossPiece02, transform.position, Quaternion.identity);
            Instantiate(BossPiece03, transform.position, Quaternion.identity);
            Instantiate(BossPiece04, transform.position, Quaternion.identity);
            Instantiate(BossPiece05, transform.position, Quaternion.identity);
            Instantiate(BossPiece06, transform.position, Quaternion.identity);
            Instantiate(BossPiece07, transform.position, Quaternion.identity);
            Instantiate(BossPiece08, transform.position, Quaternion.identity);
            Instantiate(BossPiece09, transform.position, Quaternion.identity);
            Instantiate(BossPiece10, transform.position, Quaternion.identity);
            Instantiate(BossPiece11, transform.position, Quaternion.identity);
            Instantiate(BossPiece12, transform.position, Quaternion.identity);
            Instantiate(BossPiece13, transform.position, Quaternion.identity);
            Instantiate(BossPiece14, transform.position, Quaternion.identity);
            Instantiate(BossPiece15, transform.position, Quaternion.identity);
            Instantiate(BossPiece16, transform.position, Quaternion.identity);
            Instantiate(BossPiece17, transform.position, Quaternion.identity);
            Instantiate(BossPiece18, transform.position, Quaternion.identity);
            Instantiate(BossPiece19, transform.position, Quaternion.identity);
            Instantiate(ParticleBurst, transform.position, Quaternion.identity);
            Instantiate(ParticleBurst, transform.position, Quaternion.identity);
            Instantiate(ParticleBurst, transform.position, Quaternion.identity);
            Instantiate(ParticleBurst, transform.position, Quaternion.identity);
            
            Instantiate(stardustPrefab, new Vector3(transform.position.x,
                    transform.position.y,
                    transform.position.z
                    ), transform.rotation);
             // to destory the boss
             Destroy(gameObject, .1f);



        }
        
    }

    

}
