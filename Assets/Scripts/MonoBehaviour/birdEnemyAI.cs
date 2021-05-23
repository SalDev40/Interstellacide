using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class birdEnemyAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float maxHitPoints;
    public int deathPoints = 0;


    private Confiner levelEnemies;
    public Transform player;

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

    public GameObject bird_death_particle;

    public Vector2 relativePoint;


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

            // to change bird facing with respect to Enes
            if (player.position.x > transform.position.x)
            {
                //face right
                if (!isDirectionRight)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    isDirectionRight = true;
                }
                /* if (player.position.y = transform.position.y){
                 * use the transition here.
                 */
                // to change the enemy up/down with respect to Enes.
                /*if (player.position.y > 0)
                {
                    fireRate = 1;
                    animator.SetTrigger("upLeft");
                }
                else if (player.position.y < 0)
                {
                    fireRate = 1;
                }
                else
                {
                    fireRate = 1;
                }*/
            }
            else if (player.position.x < transform.position.x)
            {
                //face left
                if (isDirectionRight)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    isDirectionRight = false;
                }
                /*if (player.position.y > 0)
                {
                    fireRate = 1;
                    animator.SetTrigger("upRight");
                }
                else if (player.position.y < 0)
                {
                    fireRate = 1;
                }
                else
                {
                    fireRate = 1;
                }*/
            }
            /*if (player.position.x == transform.position.x)
            {
                if (player.position.y > 0)
                {
                    animator.SetTrigger("upLeft");

                }
                else if (player.position.y < 0)
                {
                    animator.SetTrigger("upLeft");
                }
            }*/

            /*relativePoint = transform.InverseTransformPoint(player.position);
            if (relativePoint.y > 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
            {
                animator.SetTrigger("upLeft");
            }
            if (relativePoint.y < 0 && Mathf.Abs(relativePoint.x) < Mathf.Abs(relativePoint.y))
            {
                animator.SetTrigger("upRight");
            }*/


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
            if (!isDirectionRight)
            {
                BirdDeath_Temp = Instantiate(BirdDeath, transform.position, transform.rotation);
                GameObject bird_death_particle_temp = Instantiate(bird_death_particle, transform.position, transform.rotation);
                Destroy(BirdDeath_Temp, .50f);
                Destroy(bird_death_particle_temp, .50f);
                GameScore.RegularBirdsKilled++;
                Debug.Log("Regular Birds killed: " + GameScore.RegularBirdsKilled);
            }
            else
            {
                BirdDeath_Temp2 = Instantiate(BirdDeath2, transform.position, transform.rotation);
                GameObject bird_death_particle_temp = Instantiate(bird_death_particle, transform.position, transform.rotation);
                Destroy(BirdDeath_Temp2, .50f);
                Destroy(bird_death_particle_temp, .50f);
                GameScore.RegularBirdsKilled++;
                Debug.Log("Regular Birds killed: " + GameScore.RegularBirdsKilled);
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
