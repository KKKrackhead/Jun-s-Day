using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoSchoolNoHW : MonoBehaviour
{
    [SerializeField] TextAsset inkJSON;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.homeworkDone == false)
            {
                StartCoroutine(FirstDialogue());
            }
        }
    }

    private IEnumerator FirstDialogue()
    {
        yield return new WaitForSecondsRealtime(.5f);
        dialogueManager.EnterDialogueMode(inkJSON);
    }
}
