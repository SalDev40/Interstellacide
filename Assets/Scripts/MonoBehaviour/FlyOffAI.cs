using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyOffAI : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float maxHitPoints;
    public int deathPoints = 0;
    public Animator thruster;
    public Animator shot_anim;
    public GameObject UFO_Explosion;
    private GameObject UFO_Explosion_Temp;

    public float timeBtwShots;
    public float startTimeBtwShots;
    public float currentYAxisTarget = 5f;
    public float timer = 1f;
    public float directionSwitcher = 1f;

    private Confiner levelEnemies;
    public Transform player;
    public GameObject projectile;
    public Transform firePoint; 
    //public GameObject gun_fire;


    void Start()
    {
        GameObject Enes = GameObject.FindGameObjectWithTag("Player_Homing");
        player = Enes.transform; 
        

        
        // timeBtwShots = startTimeBtwShots;
        //timeBtwShots =  Random.Range(3, 15);
        
        //get number of enemies in level
        GameObject PlayerConfiner = GameObject.Find("PlayerConfiner");
        levelEnemies = PlayerConfiner.GetComponent<Confiner>();
        
        Invoke("NewDirectionTarget", timer);
        shootSomething();

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
            

            Vector2 temp = transform.position;
            temp.y = currentYAxisTarget;
            
            //Vector2 temp2 = player.position;
            //temp.x -= speed * Time.deltaTime;
            temp.x -=25;

            
            if (transform.position.y < currentYAxisTarget)
            {
                thruster.SetFloat("VerticalDirection", 1.0f);
                //temp.y += Random.Range(-0.2f, 1.0f)*0.5f*speed * Time.deltaTime;
                //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            
            if (transform.position.y > currentYAxisTarget)
            {
                thruster.SetFloat("VerticalDirection", -1.0f);
                //temp.y -= Random.Range(-0.2f, 1.0f)*0.5f*speed * Time.deltaTime;

                //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            //thruster.SetFloat("VerticalDirection", 0.0f);
            transform.position = Vector2.MoveTowards(transform.position, temp, speed * Time.deltaTime);
            //transform.position = temp; 
            
            /*
            if (timeBtwShots <= 0)
            {
                shot_anim.SetTrigger("ShotFired");
                //Instantiate(projectile, firePoint.position, Quaternion.identity);
                Instantiate(projectile, firePoint.position,firePoint.rotation);
                

                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                //shot_anim.SetBool("ShotFired", false);
                timeBtwShots -= Time.deltaTime;
            }
            //shot_anim.SetBool("ShotFired", false);*/
            Destroy(gameObject, 20);
          
        }



    }

    void shootSomething(){
        shot_anim.SetTrigger("ShotFired");
        //Instantiate(projectile, firePoint.position, Quaternion.identity);
        Instantiate(projectile, firePoint.position,firePoint.rotation);
        float temp_spawn = timeBtwShots + 0.25f*Random.Range(-1, 1);
        Invoke("shootSomething", temp_spawn);
    }

    void NewDirectionTarget(){
        directionSwitcher *= -1;
        if(directionSwitcher == 1){
            currentYAxisTarget = transform.position.y + Random.Range(8f,14f);
            if (currentYAxisTarget>15)
            {
                currentYAxisTarget = 15;
            }
        }else
        {
            currentYAxisTarget = transform.position.y + Random.Range(-14f,-8f);
            if (currentYAxisTarget<-30)
            {
                currentYAxisTarget = -30;
            }
        }
        Invoke("NewDirectionTarget", Random.Range(0.5f,1.75f));
    }
    

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            //var cloneExplosion = Instantiate(UFO_Explosion, transform.position, transform.rotation);
            //Destroy(cloneExplosion);
            UFO_Explosion_Temp = Instantiate(UFO_Explosion, transform.position, transform.rotation);
            Destroy(UFO_Explosion_Temp, 0.4f);
            //Invoke ("Destroy_UFO_Explosion",0.0f);
            Destroy(gameObject, 0.0f);
            GameScore.RegularUFOsKilled++;
            Debug.Log("Regular UFOs killed: " + GameScore.RegularUFOsKilled);
            
        }
    }

    void Destroy_UFO_Explosion(){
        //Instantiate(UFO_Explosion, transform.position, transform.rotation);
        UFO_Explosion_Temp = Instantiate(UFO_Explosion, transform.position, transform.rotation);
        //Destroy(UFO_Explosion_Temp, 1.0f);
        //StartCoroutine(Wait(UFO_Explosion_Temp));
        
    }

    // IEnumerator Wait(GameObject dest){
    //     yield return new WaitForSeconds(0);
    //     Destroy(dest);
    // }
    

}
