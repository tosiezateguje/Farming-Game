using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }


    [SerializeField] public Inventory PlayerInventory { get; private set; } = new Inventory();


    [SerializeField] public InventoryPanel InventoryPanel { get; private set; }




    void Start()
    {
        InventoryPanel = FindObjectOfType<InventoryPanel>();


        AddItemToPlayerInventory(
            new Hoe()
        );

        AddItemToPlayerInventory(
            new Hoe()
        );

        AddItemToPlayerInventory(new Plant("Carrot", "", 8, 3, 1, 1, 8f));

        


       
    
        
       
        Plant carrot2 = ItemList.GetItem<Plant>("Carrot");
        Debug.Log(carrot2.MaxReward);
        

    }



    public void AddItemToPlayerInventory(Item item)
    {
        PlayerInventory.AddItem(item);
        item.OnItemDestroyed += () => InventoryPanel.Refresh();
        InventoryPanel.Refresh();
    }

    


    void AddItemsToPlayerInventory(List<Item> items)
    {
        foreach (var item in items)
        {
            PlayerInventory.AddItem(item);
            item.OnItemDestroyed += () => InventoryPanel.Refresh();
        }
        InventoryPanel.Refresh();
    }

}


