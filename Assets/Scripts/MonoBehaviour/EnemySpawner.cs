using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float min_Y = -20f, max_Y = 15f;
    public GameObject enemyPrefab;
    public GameObject enemyPrefab_Green;
    public GameObject player;
    public float timer = 1f;
    public float speed = 2f;
    public float timeToDestroy = 15f;
    public float number_green_aliens = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies_Green", (timeToDestroy/number_green_aliens));
        Invoke("SpawnEnemies", timer);
    }

    // Update is called once per frame
    void Update(){
        float pos_Y = Random.Range(min_Y,max_Y);
        Vector3 temp2 = transform.position;
        temp2.x += speed * Time.deltaTime;
        temp2.y = pos_Y;
        transform.position = temp2;
        Destroy(gameObject, timeToDestroy);
    }

    void SpawnEnemies(){
      
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Invoke("SpawnEnemies", timer);
    }
    void SpawnEnemies_Green(){
      
        Instantiate(enemyPrefab_Green, transform.position, Quaternion.identity);
        //Debug.Log("Green Spawned");
        Invoke("SpawnEnemies_Green", (timeToDestroy/number_green_aliens));
    }
}
