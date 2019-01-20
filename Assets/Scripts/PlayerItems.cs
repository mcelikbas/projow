using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [HideInInspector] public Item equippedItem;
    public List<Item> items = new List<Item>();

    void Start ()
    {
        equippedItem = null;
    }

}
