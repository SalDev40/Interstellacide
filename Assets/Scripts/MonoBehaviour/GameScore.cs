using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScore : MonoBehaviour
{
    public static int RegularUFOsKilled= 0;
    public static int GreenUFOsKilled = 0;
    public static int RegularBirdsKilled = 0;
    public static int RedBirdsKilled = 0;
    public static float timelvl1 = 0.0F; 
    public static float timelvl2 = 0.0F; 
    public static float timelvl3 = 0.0F; 
    public static GameScore Instance;
    void Awake()
    {
        //create once game score object to stay alive all game
        if(Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // public void UpdateScoreUFO()
    // {
    //     UFOKilled++;
    //     Debug.Log("UFOs killed: " + UFOKilled);
    // }

    // public void UpdateScoreBirds()
    // {
    //     birdsKilled++;
    // }

//    public void OnGUI()
//    {
//      GUI.contentColor = Color.yellow;
//      GUI.Box(new Rect(5, 5, 20, 20), "Enemies killed: " + enemyKilled );
//    }
}
