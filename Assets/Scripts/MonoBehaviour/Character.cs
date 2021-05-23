using UnityEngine;

public abstract class Character : MonoBehaviour {

    /* Health, HitPoints will be shaerd reference 
    to healthBar, so they can be the same */
    public HitPoints hitPoints;
    public StarDustPoints startDustPoints;
    public float startingHitPoints;
    public float startingStarDustPoints;
    public float maxHitPoints;
    public float maxStarDustPoints;


    public enum CharacterCategory
    {
        PLAYER,
        ENEMY
    }
    public CharacterCategory characterCategory;
}