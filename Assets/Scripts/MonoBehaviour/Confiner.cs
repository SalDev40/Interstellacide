using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.Experimental.Rendering.LWRP;

public class Confiner : Character
{
    public static Confiner Instance;
    public HealthBar healthBar;
    public StarDustBar starDustBar;
    public Player Enes;
    //public GameObject globalvolume;



    public float moveSpeed = 0.03f;
    public float loadSceneSpeed = 0.03f;
    public Transform transform;
    // public Transform EnesTransform;

    public GameObject starDustPrefab;

    [HideInInspector]
    public int firstLevelEnemies= 0;
    [HideInInspector]
    public int secondLevelEnemies = 0;
    [HideInInspector]
    public int thirdLevelEnemies = 0;

    [HideInInspector]
    public  int firstLevelEnemiesDead = 0;
    [HideInInspector]
    public  int secondLevelEnemiesDead = 0;
    [HideInInspector]
    public  int thirdLevelEnemiesDead = 0;

    
    private bool droppedFirstLevelStarDust = false;
    private bool droppedSecondLevelStarDust = false;
    private bool droppedThirdLevelStarDust = false;

    // Vector2 movement = new Vector2();

    

     void Awake()
    {
        //create once confiner object to stay alive all game
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        hitPoints.value = startingHitPoints;
        startDustPoints.value = startingStarDustPoints;
        healthBar.character = this;
        starDustBar.character = this;
        Enes.enes = this;
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.Translate(moveSpeed, 0, 0);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Debug.Log("SCENE: " + scene.name); 

        //when scene is loaded get total number enemies for that screen 
        List<GameObject> rootObjects = new List<GameObject>(scene.rootCount + 1);
        scene.GetRootGameObjects(rootObjects);
        for (int j = 0; j < rootObjects.Count; ++j)
        {
            GameObject gameObject = rootObjects[j];
            if (gameObject.CompareTag("Enemy"))
            {
                 if (SceneManager.GetActiveScene().buildIndex == 1)
                    {
                        firstLevelEnemies+=1;
                    }
                 if (SceneManager.GetActiveScene().buildIndex == 2)
                    {
                         secondLevelEnemies+=1;
                    }
                 if (SceneManager.GetActiveScene().buildIndex == 3)
                    {
                        thirdLevelEnemies+=1;
                    }
            }
        }

        //when scenes load reset movement speed for camera
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("First level enemies: " + firstLevelEnemies);
            moveSpeed = loadSceneSpeed;
            
            //Set Spotlight intensity
            GameObject go = GameObject.Find("Enis_Spotlight");
            UnityEngine.Experimental.Rendering.Universal.Light2D Enis_Spotlight = go.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
            Enis_Spotlight.intensity = 10;
           
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("Second level enemies: " + secondLevelEnemies);
            moveSpeed = loadSceneSpeed;
            //Set Spotlight intensity
            GameObject go = GameObject.Find("Enis_Spotlight");
            UnityEngine.Experimental.Rendering.Universal.Light2D Enis_Spotlight = go.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
            Enis_Spotlight.intensity = 1;
           
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Debug.Log("Third level enemies: " + thirdLevelEnemies);
            // moveSpeed = 0;
            moveSpeed = loadSceneSpeed;
            //Set Spotlight intensity
            GameObject go = GameObject.Find("Enis_Spotlight");
            UnityEngine.Experimental.Rendering.Universal.Light2D Enis_Spotlight = go.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
            Enis_Spotlight.intensity = 1;
           

        }  
        
        //change spawn point for each scene so no camera issues
        if(this != null ){
         transform.position = new Vector3(
             -22.1f,
             2.8f,
             -4.164348f);
        }

        //NEW : change spawn point for each scene so no camera issues
        if(Enes != null){
            Enes.transform.position = new Vector3(
                        -230f,
                        -5f,
                        -8.328696f);
        }
        
        //OLD
        //  Enes.transform.position = new Vector3(
        //      -90f,
        //      -1f,
        //      -8.328696f);

        //ENES test Settings OLD
        //x = -46.21003, y = -5.589026, z = -5.435673

        //ENES test Settings NEW
        //x = -141.4884, y = -11.47221, z = -5.435673

        //PlayerConfinerSettings
        //x = -22.1f, y = 2.8f, z = -4.164348f;
           
    }

    void Update(){

        //drop stardust if all level enemies killed
        //stop confiner camera movement make scene static
        // if (SceneManager.GetActiveScene().buildIndex == 1 && !droppedFirstLevelStarDust)
        // {
        //     if(firstLevelEnemiesDead == firstLevelEnemies){
        //         Debug.Log("Confiner First Level Enemies Dead: " +  firstLevelEnemiesDead);
        //         Debug.Log("DROPPING STARDUST FIRST LEVEL");
        //         droppedFirstLevelStarDust = true;
        //         moveSpeed = 0;
        //         print("STOPPED SCENE 1: " + moveSpeed);
        //         // Instantiate(starDustPrefab, new Vector3(Enes.transform.position.x + 30,
        //         // Enes.transform.position.y,
        //         // Enes.transform.position.z
        //         // ), transform.rotation);
        //     }
        // }
        
        /*if (SceneManager.GetActiveScene().buildIndex == 2 && !droppedSecondLevelStarDust)
        {
            if(secondLevelEnemiesDead == secondLevelEnemies){
                Debug.Log("Confiner Second Level Enemies Dead: " +  secondLevelEnemiesDead);
                Debug.Log("DROPPING STARDUST SECOND LEVEL");
                moveSpeed = 0;
                print("STOPPED SCENE 2: " + moveSpeed);
                droppedSecondLevelStarDust = true;
                Instantiate(starDustPrefab, new Vector3(Enes.transform.position.x + 30,
                Enes.transform.position.y,
                Enes.transform.position.z
                ), transform.rotation);

            }
            
        }*/
        
        // if (SceneManager.GetActiveScene().buildIndex == 3 && !droppedThirdLevelStarDust)
        // {
        //     if(thirdLevelEnemiesDead == thirdLevelEnemies){
        //         Debug.Log("Confiner Third Level Enemies Dead: " +  thirdLevelEnemiesDead);
        //         Debug.Log("DROPPING STARDUST THIRD LEVEL");
        //         moveSpeed = 0;
        //         droppedThirdLevelStarDust = true;
        //         Instantiate(starDustPrefab, new Vector3(Enes.transform.position.x + 30,
        //         Enes.transform.position.y,
        //         Enes.transform.position.z
        //         ), transform.rotation);

        //     }
        // }       
    }

   

    
}
