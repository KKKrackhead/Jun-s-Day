using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using System;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";

    private const string PORTRAIT_TAG = "portrait";

    PlayerController playerController;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;
    [SerializeField] private GameObject panelYellow;
    [SerializeField] private GameObject panelBlue;
    [SerializeField] private Image talker;
    [SerializeField] private Sprite[] talkerSprites;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("There is more than 1 instance!");
        }
        instance = this;
    }

    public static DialogueManager GetInsatnce()
    {
        return instance;
    }

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
    }

    private void Update()
    {
        if (dialogueIsPlaying && playerController.interacting)
        {
            ContinueStory();
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();

            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');

            if(splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be parsed" + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    if (tagValue == "Narration") displayNameText.text = null;

                    displayNameText.text = tagValue;

                    if (tagValue == "Jun")
                    {
                        panelYellow.SetActive(true);
                        panelBlue.SetActive(false);
                    }
                    else
                    {
                        panelBlue.SetActive(true);
                        panelYellow.SetActive(false);
                    }
                        
                    break;

                case PORTRAIT_TAG:
                    if (tagValue == "Jun") talker.sprite = talkerSprites[0];
                    else if (tagValue == "Nida") talker.sprite = talkerSprites[1];
                    else if (tagValue == "Nerd") talker.sprite = talkerSprites[2];
                    else if (tagValue == "Rita") talker.sprite = talkerSprites[3];
                    else if (tagValue == "Goons") talker.sprite = talkerSprites[4];
                    else if (tagValue == "Donnie") talker.sprite = talkerSprites[5];
                    else if (tagValue == "Ariel") talker.sprite = talkerSprites[6];
                    else talker.sprite = talkerSprites[0];
                    break;
            }

        }
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSecondsRealtime(.2f);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
}