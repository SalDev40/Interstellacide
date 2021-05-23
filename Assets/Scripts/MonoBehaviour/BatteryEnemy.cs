using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatteryEnemy : MonoBehaviour
{
    public float speed;
    public Transform player;
    private Material shield_material;
    private float fade;
    private float starttime;
    private bool notdead = true;
    
    public GameObject batteryPrefab;

    // animate the game object from -1 to +1 and back
    private float minimum = 0.2F;
    private float maximum =  0.9F;

    // starting value for the Lerp
    static float t = 0.0f;



    void Start()
    {
        GameObject Enes = GameObject.FindGameObjectWithTag("Player");
        player = Enes.transform;
        shield_material = GetComponent<SpriteRenderer>().material;
        starttime = Time.time;
        notdead = true;

    }

    void Update()
    {
        GameObject isAliveEnes = GameObject.FindGameObjectWithTag("Player");
        //check if enes is alive, if he is continue AI, else print hes dead


        // animate the position of the game object...
        fade = Mathf.Lerp(minimum, maximum, t);
        shield_material.SetFloat("_Fade", fade);

        // .. and increase the t interpolater
        t += 0.9f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 0.9f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

        if((notdead == false) && (fade < 0.35f)){
            Destroy(gameObject);
        }


        /*if(notdead == false){
            fade = 0.8f - (0.4f* Mathf.PingPong((Time.time - starttime)*3, 1));
            shield_material.SetFloat("_Fade", fade);
        }

        if((notdead == true) && (fade < 0.5f)){
            fade = Mathf.Lerp(0.5f, 0f, 0.5));
            shield_material.SetFloat("_Fade", fade);    

        }*/

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
            Destroy(gameObject, 50);

        }



    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            
            bool randomDropBattery =  (Random.Range(0, 2) == 0);
            if (randomDropBattery)
            {
                Instantiate(batteryPrefab, new Vector3(transform.position.x,
                    transform.position.y,
                    transform.position.z
                    ), transform.rotation);
            }
            notdead = false;
            //Destroy(gameObject, 0f);
            GameScore.GreenUFOsKilled++;
            Debug.Log("Green UFOs killed: " + GameScore.GreenUFOsKilled);
            
        }
    }

   
}
