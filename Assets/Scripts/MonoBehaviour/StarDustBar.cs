using UnityEngine;
using UnityEngine.UI;

public class StarDustBar : MonoBehaviour
{
    /* Shared reference with Player  */
    public StarDustPoints starDustPoints;

    [HideInInspector]
    /* Player character */
    public Character character;

    public Image meterImage;

    float maxStarDustPoints;

    void Start()
    {
        maxStarDustPoints = character.maxStarDustPoints;
    }

    void Update()
    {
        if (character != null)
        {
            meterImage.fillAmount = starDustPoints.value / maxStarDustPoints;
        }
    }
}
