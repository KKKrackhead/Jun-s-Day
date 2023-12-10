using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    PlayerController playerController;
    InventoryManager inventoryManager;

    public bool searchBag;
    public bool homeworkDone;


    private void Start()
    {
        PlayerPrefs.Save();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();

        homeworkDone = false;
        searchBag = true;
    }

    private void Update()
    {
        if (searchBag)
        {
            if(inventoryManager.SearchItem("Bag") == true) searchBag = false;
        }

        Debug.Log(searchBag + "" + homeworkDone);
        if(playerController.currentPlace == Place.Class)
        {
            if (inventoryManager.SearchItem("Homework") == true) homeworkDone = true;
            else homeworkDone = false;
        }
    }
}
