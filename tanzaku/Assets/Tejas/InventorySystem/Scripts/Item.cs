    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    public int quantity;
    [SerializeField]
    public Sprite sprite;
    [TextArea]
    [SerializeField]
    public string itemDescription;
    private InventoryManager inventoryManager;
    public ItemSO itemSO;
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        itemSO.playerHasItem = false;
        itemSO.questComplete = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            if (leftOverItems <= 0)
            {
                Destroy(gameObject);
                itemSO.playerHasItem = true;
            }
            else {
                quantity = leftOverItems;
                
            }
                
        }
    }
}
