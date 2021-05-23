using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponEnemy : MonoBehaviour
{
    public float speed;
    public Transform player;


    public GameObject weaponPrefab;



    void Start()
    {
        GameObject Enes = GameObject.FindGameObjectWithTag("Player");
        player = Enes.transform;

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


            Vector3 temp = transform.position;
            Vector3 temp2 = player.position;
            temp.x -= speed * Time.deltaTime;

            if (temp.y < temp2.y)
            {
                temp.y += Mathf.Sin(Time.deltaTime) * 0.5f * speed;
                // temp.y +=0.5f * speed * Time.deltaTime;
            }

            if (temp.y > temp2.y)
            {
                temp.y -= Mathf.Sin(Time.deltaTime) * 0.5f * speed;
                // temp.y -=*0.5f * speed * Time.deltaTime;

            }
            transform.position = temp;
            // Destroy(gameObject, 50);

        }



    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerShot"))
        {

            Instantiate(weaponPrefab, new Vector3(transform.position.x,
                transform.position.y,
                transform.position.z
                ), transform.rotation);
            Destroy(gameObject, 0.0f);
        }
    }

}
