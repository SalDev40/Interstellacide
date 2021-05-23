using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UpdateStats : MonoBehaviour
{
    TMPro.TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMPro.TextMeshProUGUI> ();
        score.text = "Regular Aliens Killed: " + GameScore.RegularUFOsKilled
        + "\nGreen Aliens Killed: " + GameScore.GreenUFOsKilled
        + "\nRegular Birds Killed: " + GameScore.RegularBirdsKilled
        + "\nRed Birds Killed: " + GameScore.RedBirdsKilled;
        score.text += GameScore.timelvl1 > 0.0F? "\nTime spent on Lvl 1: " + (int)Math.Round(GameScore.timelvl1) + " sec" : "";
        score.text += GameScore.timelvl2 > 0.0F? "\nTime spent on Lvl 2: " + (int)Math.Round(GameScore.timelvl2) + " sec" : "";
        score.text += GameScore.timelvl3 > 0.0F? "\nTime spent on Lvl 3: " + (int)Math.Round(GameScore.timelvl3) + " sec" : "";
        GameScore.RegularUFOsKilled = GameScore.GreenUFOsKilled = GameScore.RegularBirdsKilled = GameScore.RedBirdsKilled = 0;
        GameScore.timelvl1 = GameScore.timelvl2 = GameScore.timelvl3 = 0.0F;
    }
}
