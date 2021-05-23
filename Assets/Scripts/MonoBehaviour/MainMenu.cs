using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("TutorialScene");
    }

    // public void OptionsMenu{

    // }

     public void GoMainMenu (){
        GameObject toDestroy = GameObject.Find("PlayerConfiner");
        Debug.Log("GOING HOME");
        // Application.Quit();
        Destroy(toDestroy);
        SceneManager.LoadScene(0);

    }

    public void QuitGame(){
        SceneManager.LoadScene(5);
        Application.Quit();
    }
}
