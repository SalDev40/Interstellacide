using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_MainMenu : MonoBehaviour
{
    public void PlayGame(){
        GameObject confiner = GameObject.Find("PlayerConfiner");
        GameObject settingsMenu = confiner.transform.GetChild(0).gameObject;


        SwitchSettingsMenu sceneToLoad = settingsMenu.GetComponent<SwitchSettingsMenu>();
        Debug.Log("Loading Screen: " + sceneToLoad.scene);
        SceneManager.LoadScene(sceneToLoad.scene, LoadSceneMode.Single);
    }

    public void QuitGame(){
        SceneManager.LoadScene(5);
        Application.Quit();
    }
}

