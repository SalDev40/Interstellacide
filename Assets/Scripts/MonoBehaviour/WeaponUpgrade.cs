using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WeaponUpgrade : MonoBehaviour
{

    public Sprite Level2upgradedGun;
    public Sprite Level3upgradedGun;
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Level2upgradedGun;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = Level3upgradedGun;

        }
    }
}
