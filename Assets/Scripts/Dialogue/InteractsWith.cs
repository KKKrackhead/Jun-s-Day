using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractsWith : MonoBehaviour
{
    [SerializeField] TextAsset inkJSON;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] PlayerController player;

    bool playerInRange;

    private void Start()
    {
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(playerInRange && player.interacting)
        {
            dialogueManager.EnterDialogueMode(inkJSON);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }
}
