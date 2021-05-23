using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class redBIRDai : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float maxHitPoints;
    public int deathPoints = 0;

    public bool canShoot;

    private float timeBtwShots;
    public float startTimeBtwShots;
    
    public GameObject bulletBirdRE;

    private Confiner levelEnemies;
    public Transform player;
    public Transform firePoint;
    // for animations
    public Animator animator;
    public bool isDirectionRight; // check enes direction for birdenemy

    // for death animation using prefab and Instantiate
    public GameObject BirdDeath;
    private GameObject BirdDeath_Temp;
    public GameObject BirdDeath2;
    private GameObject BirdDeath_Temp2;
    public GameObject BirdFlash;
    private GameObject BirdFlash_Temp;
    public GameObject BirdFlash2;
    private GameObject BirdFlash2_Temp;




    // Start is called before the first frame update
    void Start()
    {
        GameObject Enes = GameObject.FindGameObjectWithTag("Player");
        player = Enes.transform;

        timeBtwShots = startTimeBtwShots;

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

            
            //shooting at enes:
            if (timeBtwShots <= 0)
            {
                
                Instantiate(bulletBirdRE, firePoint.position, firePoint.rotation);


                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                
                timeBtwShots -= Time.deltaTime;
            }

            // to change bird facing with respect to Enes
            if (player.position.x > transform.position.x)
            {
                //face right
                if (!isDirectionRight)
                {
                    //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    transform.Rotate(0f, 180f, 0f);
                    isDirectionRight = true;
                }
                
            }
            else if (player.position.x < transform.position.x)
            {
                //face left
                if (isDirectionRight)
                {
                    //transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    transform.Rotate(0f, 180f, 0f);
                    isDirectionRight = false;
                }
                
            }
            

        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            DecreaseHitPoints(1f);
           
        }

    }
    public void DecreaseHitPoints(float amount)
    {

        maxHitPoints = maxHitPoints - amount;


        if (maxHitPoints <= deathPoints)
        {
            levelEnemies.thirdLevelEnemiesDead += 1;
            Debug.Log("THIRD LEVEL ENEMIES DEAD: " +
            levelEnemies.thirdLevelEnemiesDead);

            
            // to play death animation for right and left side.
            if (!isDirectionRight)
            {
                BirdDeath_Temp = Instantiate(BirdDeath, 
                transform.position, transform.rotation);
                Destroy(BirdDeath_Temp, .50f);
                GameScore.RedBirdsKilled++;
                Debug.Log("Red Birds killed: " + GameScore.RedBirdsKilled);
            }
            else
            {
                BirdDeath_Temp2 = Instantiate(BirdDeath2, 
                transform.position, transform.rotation);
                Destroy(BirdDeath_Temp2, .50f);
                GameScore.RedBirdsKilled++;
                Debug.Log("Red Birds killed: " + GameScore.RedBirdsKilled);
            }


            // to destory the player
            Destroy(gameObject, .1f);


        }
        /*else
        {
            if (!isDirectionRight)
            {
                BirdFlash_Temp = Instantiate(BirdFlash, transform.position, transform.rotation);
                Destroy(BirdFlash_Temp, .050f);
            }
            else
            {
                BirdFlash2_Temp = Instantiate(BirdFlash2, transform.position, transform.rotation);
                Destroy(BirdFlash2_Temp, .05f);
            }
        }*/
    }





}
