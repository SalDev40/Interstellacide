using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enis_Shield : MonoBehaviour
{
    // Start is called before the first frame update
    private Material shield_material;
    private float fade;
    
    private float starttime;
    private Transform player;
   
    private Vector2 target;

   
    // [MenuItem("GameObject/Create Material")]
    void Start()
    {
        shield_material = GetComponent<SpriteRenderer>().material;
        fade = 0f;
        
        starttime = Time.time;
        player = GameObject.Find("Enes_Body").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        fade = 0.1f+ (0.6f * Mathf.PingPong((Time.time - starttime)*9, 1));
      
        shield_material.SetFloat("_Fade", fade);
     
    }
   
}
