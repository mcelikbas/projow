using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private string itemName;
    private string description;

    public Item (string itemName, string description)
    {
        ItemName = itemName;
        Description = description;
    }

    public string ItemName { get => itemName; set => itemName = value; }
    public string Description { get => description; set => description = value; }


}
