using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner_Level2 : MonoBehaviour
{
    public float min_Y = -100f, max_Y = 100f;
    public GameObject enemyPrefab_UFO_Level2;
    public GameObject enemyPrefab_Bird;
    public GameObject enemyPrefab_Green;
    public GameObject enemyPrefab_Gold;
    public GameObject StarDust_Prefab;
    public float speed = 2f;

    //UFO
    public float timer_UFO = 5f;
        
    //Bird
    public float timer_Bird = 2f;
        
    //Green
    private float timer_Green;
        
    //Gold
    private float timer_Gold;
    

    public float timeToDestroy = 15f;

    // Start is called before the first frame update
    void Start()
    {
        timer_Green = timeToDestroy*0.2f;
        timer_Gold = timeToDestroy*0.75f;

        Invoke("SpawnEnemies_UFO", timer_UFO);
        Invoke("SpawnEnemies_Bird", timer_Bird);
        Invoke("SpawnEnemies_Green", timer_Green);
        Invoke("SpawnEnemies_Gold", (timeToDestroy-3));
        Invoke("SpawnEnemies_StarDust", (timeToDestroy-1));
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update(){
        float pos_Y = Random.Range(min_Y,max_Y);
        Vector3 temp2 = transform.position;
        temp2.x += speed * Time.deltaTime;
        temp2.y = pos_Y;
        transform.position = temp2;
        
        
    }

    void SpawnEnemies_UFO(){
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //float pos_Y = Random.Range(min_Y,max_Y);
        //Vector3 temp = transform.position;
        //temp.y = pos_Y;
        Instantiate(enemyPrefab_UFO_Level2, transform.position, Quaternion.identity);
        Invoke("SpawnEnemies_UFO", timer_UFO);
    }

    void SpawnEnemies_Bird(){
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //float pos_Y = Random.Range(min_Y,max_Y);
        //Vector3 temp = transform.position;
        //temp.y = pos_Y;
        Instantiate(enemyPrefab_Bird, transform.position, Quaternion.identity);
        Invoke("SpawnEnemies_Bird", timer_Bird);
    }

    void SpawnEnemies_Green(){
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //float pos_Y = Random.Range(min_Y,max_Y);
        //Vector3 temp = transform.position;
        //temp.y = pos_Y;
        Instantiate(enemyPrefab_Green, transform.position, Quaternion.identity);
        Invoke("SpawnEnemies_Green", timer_Green);
    }

    void SpawnEnemies_Gold(){
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //float pos_Y = Random.Range(min_Y,max_Y);
        //Vector3 temp = transform.position;
        //temp.y = pos_Y;
        Instantiate(enemyPrefab_Gold, transform.position, Quaternion.identity);
        Invoke("SpawnEnemies_Gold", timer_Gold);
    }

    void SpawnEnemies_StarDust(){
        Instantiate(StarDust_Prefab, transform.position, Quaternion.identity);
    }
}
