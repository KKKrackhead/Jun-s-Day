using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomLevel : MonoBehaviour
{
    [SerializeField] TextAsset inkJSON;
    [SerializeField] DialogueManager dialogueManager;

    private void Start()
    {
        StartCoroutine(FirstDialogue());
    }

    private IEnumerator FirstDialogue()
    {
        yield return new WaitForSecondsRealtime(.8f);
        dialogueManager.EnterDialogueMode(inkJSON);
    }
}
