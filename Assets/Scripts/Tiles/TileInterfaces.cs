using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFertilizable
{
    void FertilizeTile();
}

public interface IHasInventory
{
    Inventory Inventory { get; set;}

    void AddItemToInventory(Item item);
    void AddItemsToInventory(List<Item> items);

}

public interface IHasItemFilter
{
    List<Item> ItemFilter { get; set; }
}

public interface IFertile
{
    public GrowingEntity GrowingEntity { get; set; }
    void Plant(Item item);
}