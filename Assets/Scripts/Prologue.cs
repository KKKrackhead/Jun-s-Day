using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URPGlitch;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;


public class Prologue : MonoBehaviour
{
    [SerializeField] FadeScreen fadeScreen;
    [SerializeField] DialogueManager dialogueManager;
    [SerializeField] TextAsset inkJSON;
    [SerializeField] GameObject PP;

    int phase;

    private void Start()
    {
        StartCoroutine(Starting());
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E)) phase++;

        if(phase == 1)
        {
            fadeScreen.BtC();
        }
        if(phase == 3)
        {
            PP.SetActive(true);
        }
        if(phase == 4)
        {
            fadeScreen.CtB();
            StartCoroutine(Ending());
        }
    }

    private IEnumerator Starting()
    {
        yield return new WaitForSecondsRealtime(2f);
        dialogueManager.EnterDialogueMode(inkJSON);
    }

    private IEnumerator Ending()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(2);
    }
}
