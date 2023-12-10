using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Items> ItemsList = new List<Items>();

    public Transform itemContent;
    public GameObject inventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItems(Items items)
    {
        ItemsList.Add(items);
    }

    public void RemoveItems(Items items)
    {
        ItemsList.Remove(items);
    }

    public void listItems()
    {
        foreach(Transform items in itemContent)
        {
            Destroy(items.gameObject);
        }

        foreach(var items in ItemsList)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemDesc = obj.transform.Find("ItemDesc").GetComponent<TextMeshProUGUI>();
            var itemSprite = obj.transform.Find("ItemSprite").GetComponent<Image>();

            itemName.text = items.itemName;
            itemDesc.text = items.itemDesc;
            itemSprite.sprite = items.itemSprite;
        }
    }

    public bool SearchItem(string itemWanted)
    {
        foreach (var items in ItemsList)
        {
            if (ItemsList.Count <= 0) return false;

            for(int i = 0; i <= ItemsList.Count; i++)
            {
                if (ItemsList[i].name == itemWanted)
                {
                    return true;
                }
            }
        }
        return false;
    }
}