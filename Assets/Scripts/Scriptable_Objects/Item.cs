using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject {

    public string objectName;
    public Sprite sprite;

    public int quantity;

//multiple items can be stored in players inventory such as coins
    public bool stackable; 

    public enum ItemType
    {
        COIN,
        HEALTH,
        STARDUST
    }

    public ItemType itemType;
}