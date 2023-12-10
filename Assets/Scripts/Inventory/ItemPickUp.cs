using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Items items;
    bool playerInRange;
    [SerializeField] GameObject cue;
    PlayerController playerController;
    [SerializeField] TextAsset inkJSON;
    DialogueManager dialogueManager;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    public void PickUp()
    {
        dialogueManager.EnterDialogueMode(inkJSON);
        InventoryManager.Instance.AddItems(items);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (playerController.interacting && playerInRange) PickUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            cue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
        cue.SetActive(false);
    }
}
