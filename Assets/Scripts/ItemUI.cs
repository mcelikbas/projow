using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    private Item equippedItem;
    private Text text;


    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update ()
    {
        equippedItem = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerItems>().equippedItem;
        if (equippedItem != null)
        {
            text.text = "Equipped Item: " + equippedItem.ItemName;
        }
    }
}
