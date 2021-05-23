using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    /* Shared reference with Player  */
    public HitPoints hitPoints;

    [HideInInspector]
    /* Player character */
    public Character character;

    public Image meterImage;

    public Text hpText;

    float maxHitPoints;

    void Start()
    {
        maxHitPoints = character.maxHitPoints;
    }

    void Update()
    {
        /* Update healthbar based on players life value */
        if (character != null)
        {
            meterImage.fillAmount = hitPoints.value / maxHitPoints;
            hpText.text = "" + hitPoints.value;
        }
    }
}
