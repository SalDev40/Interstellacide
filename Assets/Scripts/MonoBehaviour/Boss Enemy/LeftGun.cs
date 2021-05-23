using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGun : MonoBehaviour
{
    
    public Rigidbody2D leftGun;
    private Transform player;
    Vector2 playerPos;
    public float angleAdjust = 0f;
    private float angle;
    public Transform firePoint;
    public float timeBtwShots;
    public GameObject projectile;
    private bool gunOn;
    private Vector2 lookDir;
    private float shotTimer; 

    // Start is called before the first frame update
    void Start()
    {
        GameObject Enes = GameObject.FindGameObjectWithTag("Player");
        player = Enes.transform;
        shotTimer = timeBtwShots;
        
    }

    // Update is called once per frame
    void Update()
    {
        shotTimer -= Time.deltaTime;
        playerPos = player.position;
    }

    void FixedUpdate(){
        Vector2 lookDir = playerPos - leftGun.position;
        angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg + angleAdjust;
        //Debug.Log(angle);
        if(angle > 90 && angle < 315){
            gunOn = false;
        } else{
            leftGun.rotation = angle;
            gunOn = true;
        }
        //gunOn = true;
        if(gunOn == true && shotTimer <= 0){
            Invoke("shoot", 0.1f);
            shotTimer = timeBtwShots;
        }

    }

    void shoot(){
        Instantiate(projectile, firePoint.position,firePoint.rotation);
    }
}
