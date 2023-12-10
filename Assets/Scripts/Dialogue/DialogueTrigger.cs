using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] GameObject cue;
    PlayerController playerController;
    DialogueManager dialogueManager;

    [SerializeField] private TextAsset inkJSON;

    bool playerInRange;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

        cue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && playerController.interacting && dialogueManager.dialogueIsPlaying == false)        
        {
            dialogueManager.EnterDialogueMode(inkJSON);
            if (GetComponent<ItemPickUp>() != null)
            {
                Debug.Log("Here");
                GetComponent<ItemPickUp>().PickUp();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("touch");
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