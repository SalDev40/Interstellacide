using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class Player : MonoBehaviour
{
    public Sprite Level2upgradedGun;
    public Sprite Level3upgradedGun;
    public GameObject weaponGunCase;
    
    public int damageStrength;

    Coroutine damageCoroutine;

    public HitPoints hitPoints;
    public StarDustPoints starDustPoints;
    public GameObject enisExplosion;
    private GameObject temp_enis;
    private bool death_called;

    public GameObject shield;
    private float shield_time = 0.2f;
    CircleCollider2D m_Collider;
    
    
    [HideInInspector]
    public Character enes;
    private float maxStarDustPoints;
    private float maxHitPoints;
    

    public void Awake(){
        
    }

    public void Start()
    {
        maxHitPoints = enes.maxHitPoints;
        maxStarDustPoints = enes.maxStarDustPoints;
        death_called = false;
        Debug.Log("1770471");
        if(m_Collider = gameObject.GetComponent<CircleCollider2D>()){ Debug.Log("1880471");};
        Debug.Log("1770471");
    
    }

    public void Update(){

    }



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("weapon2"))
        {         
            weaponGunCase.GetComponent<SpriteRenderer>().sprite = Level2upgradedGun;
                        collision.gameObject.SetActive(false);

        }


        if (collision.gameObject.CompareTag("weapon3"))
        { 
        
            weaponGunCase.GetComponent<SpriteRenderer>().sprite = Level3upgradedGun;
                        collision.gameObject.SetActive(false);


        }
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                switch (hitObject.itemType)
                {
                    case Item.ItemType.HEALTH:
                        IncreaseHitPoints(hitObject.quantity);
                        collision.gameObject.SetActive(false);
                        break;
                    case Item.ItemType.STARDUST:

                        //pick up star dust and upgrade gun
                        IncreaseStarDustPoints(hitObject.quantity);
                        if (SceneManager.GetActiveScene().buildIndex == 1)
                        {
                            GameScore.timelvl1 = Time.timeSinceLevelLoad;
                            SceneManager.LoadScene(2);
                        }
                        if (SceneManager.GetActiveScene().buildIndex == 2)
                        {
                            GameScore.timelvl2 = Time.timeSinceLevelLoad;
                            SceneManager.LoadScene(3);
                        }

                        break;

                    default:
                        break;
                }
            }
        }
        if (collision.gameObject.CompareTag("EnemyShot"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("Shot by enemy");
                
                //@TODO: add random number generator 0.13-0.22f
                DecreaseHitPoints(0.20f);
                GameObject shield_temp = Instantiate(shield, transform.position, transform.rotation);
                Destroy(shield_temp,shield_time);
                

            }
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                DecreaseHitPoints(0.5f);
                GameObject shield_temp = Instantiate(shield, transform.position, transform.rotation);
                Destroy(shield_temp,shield_time);

            }
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                DecreaseHitPoints(0.5f);
                GameObject shield_temp = Instantiate(shield, transform.position, transform.rotation);
                Destroy(shield_temp,shield_time);
            }
        }
        
    }

    public void IncreaseHitPoints(int amount)
    {
        hitPoints.value = hitPoints.value + amount;
        if(hitPoints.value >= maxHitPoints){
            hitPoints.value = maxHitPoints;
        }
        print("INCREASE HP by: " +  amount + ". New value: " + hitPoints.value);
    }

    public void DecreaseHitPoints(float amount)
    {
        hitPoints.value = hitPoints.value - amount;      
        print("DAMAGE HP by: " + amount + ". New value: " + hitPoints.value);

        if(hitPoints.value <= 0){
            EndGame();
        }
    }
    public void IncreaseStarDustPoints(int amount)
    {
        if (starDustPoints.value < maxStarDustPoints)
        {
            starDustPoints.value  = starDustPoints.value  + 1;
            print("Adjusted star dust points by: " + 1 + ". New value: "
             + starDustPoints.value );

            //if all stardust collected then end the game
            if(starDustPoints.value == maxStarDustPoints){
                GameObject toDestroy = GameObject.Find("PlayerConfiner");
                GameScore.timelvl3 = Time.timeSinceLevelLoad;
                SceneManager.LoadScene(7);
                
                //destroy player confiner children objects 
                Destroy(toDestroy.transform.GetChild(0).gameObject, 0.4f);
                Destroy(toDestroy.transform.GetChild(1).gameObject, 0.4f);
                Destroy(toDestroy.transform.GetChild(3).gameObject, 0.4f);
                Destroy(toDestroy.transform.GetChild(4).gameObject, 0.4f);
                Destroy(toDestroy.transform.GetChild(5).gameObject, 0.4f);
                Destroy(toDestroy.transform.GetChild(6).gameObject, 0.4f);
                // Application.Quit();
            }
        }
    }
  



    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DamageUfoAlien"))
        {
            Debug.Log("Enter enemy...");
        }
    }

   void OnCollisionStay2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            // Debug.Log("Taking damage,....");
            hitPoints.value = hitPoints.value - 0.01f;
            print("DAMAGE HP by: " + 0.01f + ". New value: " + hitPoints.value);
            
            GameObject shield_temp = Instantiate(shield, transform.position, transform.rotation);
            Destroy(shield_temp,shield_time);
                

            if (hitPoints.value <= 0)
            {
                Debug.Log("Ending game...");
                EndGame();
            }
        }
        if(collision.gameObject.CompareTag("DamageUfoAlien"))
        {
            // Debug.Log("Taking damage,....");
            hitPoints.value = hitPoints.value - 0.01f;
            print("DAMAGE HP by: " + 0.01f + ". New value: " + hitPoints.value);

            if (hitPoints.value <= 0)
            {
                Debug.Log("Ending game...");
                EndGame();
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("DamageUfoAlien"))
        {
            Debug.Log("Enter enemy...");
        }
    }


    void EndGame(){

        //Enis explosion
        //temp_enis = Instantiate(enisExplosion, transform.position, transform.rotation);     
        //Destroy(temp_enis, 3.0f);
        if(death_called == false){
            temp_enis = Instantiate(enisExplosion, transform.position, transform.rotation);
            death_called = true;
            Destroy(temp_enis, 3.0f);
            m_Collider.enabled = false;
        }
        //if(m_Collider = toDestroy.transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>()){ Debug.Log("1880471");};
        //m_Collider.enabled = false;
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject.transform.GetChild(1).gameObject);


        Debug.Log("ENES IS Dead");
        GameObject toDestroy = GameObject.Find("PlayerConfiner");
        // Application.Quit();
        
        //m_Collider.enabled = false;
        Invoke("DeathScreen", 3.1f);
        //destroy player confiner children objects 
        Destroy(toDestroy, 5f);
        Destroy(toDestroy.transform.GetChild(0).gameObject, 5f);
        Destroy(toDestroy.transform.GetChild(1).gameObject, 5f);
        Destroy(toDestroy.transform.GetChild(3).gameObject, 5f);
        Destroy(toDestroy.transform.GetChild(4).gameObject, 5f);
        Destroy(toDestroy.transform.GetChild(5).gameObject, 5f);
        Destroy(toDestroy.transform.GetChild(6).gameObject, 5f);
        
        
        // StartCoroutine(waiter());
        
        // Invoke("SceneManager.LoadScene(6)", 2f);
        //Invoke("ChangeScene()",5.5f);

        // Time.timeScale = 0;
       


        //MAIN CAMERA DO NOT REMOVE UNTIL END
        // Destroy(toDestroy.transform.GetChild(2).gameObject);

    }

    void DeathScreen(){
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameScore.timelvl1 = Time.timeSinceLevelLoad;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            GameScore.timelvl2 = Time.timeSinceLevelLoad;
        }
        else if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameScore.timelvl3 = Time.timeSinceLevelLoad;
        }
        SceneManager.LoadScene(6);
    }

   

    IEnumerator waiter()
{
   
    //Wait for 4 seconds
    float counter = 0;
      //Wait for 4 seconds
    float waitTime = 1.7f;
    while (counter < waitTime)
    {
        //Increment Timer until counter >= waitTime
        counter += Time.deltaTime;
        //Debug.Log("We have waited for: " + counter + " seconds");
        //Wait for a frame so that Unity doesn't freeze
        yield return null;
        
    }

    // SceneManager.LoadScene(6);
    
}


    
    // public  IEnumerator DamageCharacter(float damage, float interval)
    // {
    //     while (true)
    //     {
    //         hitPoints.value = hitPoints.value - damage;
    //         print("DAMAGE HP by: " + damage + ". New value: " + hitPoints.value);

    //         if (hitPoints.value <= 0)
    //         {
    //             Debug.Log("Ending game...");
    //             EndGame();
    //             break;
    //         }

    //         if (interval > float.Epsilon)
    //         {
    //             yield return new WaitForSeconds(interval);
    //         }
    //         else
    //         {
    //             break;
    //         }
    //     }
    // }
}







