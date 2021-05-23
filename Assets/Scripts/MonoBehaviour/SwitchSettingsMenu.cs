using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSettingsMenu : MonoBehaviour
{
 
    public int scene;
    // GameObject toLoad;
    public void SwitchToSettings(){ 
        Time.timeScale = 0;
        GameObject Confiner = GameObject.Find("PlayerConfiner");
        GameObject toLoad = Confiner.transform.GetChild(4).gameObject;
        GameObject toLoadEnes = Confiner.transform.GetChild(1).gameObject;
        toLoad.SetActive(true);
        // toLoadEnes.SetActive(false);
    }

    public void BackToGame (){
        Time.timeScale = 1;

        GameObject Confiner = GameObject.Find("PlayerConfiner");
        GameObject toLoad = Confiner.transform.GetChild(4).gameObject;
        GameObject toLoadEnes = Confiner.transform.GetChild(1).gameObject;
        toLoad.SetActive(false);
        // toLoadEnes.SetActive(true);
    }
   
    
    public void QuitGame(){
         GameObject toDestroy = GameObject.Find("PlayerConfiner");
            //destroy player confiner children objects 
        Destroy(toDestroy.transform.GetChild(0).gameObject);
        Destroy(toDestroy.transform.GetChild(1).gameObject);
        Destroy(toDestroy.transform.GetChild(3).gameObject);
        Destroy(toDestroy.transform.GetChild(4).gameObject);
        Destroy(toDestroy.transform.GetChild(5).gameObject);
        Destroy(toDestroy.transform.GetChild(6).gameObject);
        SceneManager.LoadScene(5);
        Application.Quit();
    }

   
   
}
