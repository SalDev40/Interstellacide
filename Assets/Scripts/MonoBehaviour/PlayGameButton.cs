using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButton : MonoBehaviour
{
    // Change from tutorialScene to firstScene(Start Game).
    public void playButtonTutorial()
    {
        SceneManager.LoadScene(1);
    }

   
}
