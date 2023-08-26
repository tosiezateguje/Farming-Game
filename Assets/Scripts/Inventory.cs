using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[System.Serializable]
public class Inventory
{
    public List<Item> Items { get; private set; } = new List<Item>();



    public void AddItem(Item item)
    {
        if (item is IStackable stackableItem)
        {
            Item existingItem = Items.FirstOrDefault(i => i.Name == item.Name);
            if (existingItem is IStackable existingStackableItem)
                existingStackableItem.Quantity += stackableItem.Quantity;
            else
            {
                Items.Add((Item)stackableItem);
                item.OnItemDestroyed += () => DestroyItem(item);
            }
        }
        else
        {
            Items.Add(item);
            item.OnItemDestroyed += () => DestroyItem(item);
        }
    }

    public void DestroyItem(Item item)
    {
        if (item is IStackable stackableIte)
        {
            stackableIte.Quantity--;
            if (stackableIte.Quantity <= 0)
                Items.Remove(item);
        }
        else
            Items.Remove(item);
    }



}
