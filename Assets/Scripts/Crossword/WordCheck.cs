using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class WordCheck : MonoBehaviour
{
    [SerializeField] private DesiredWord word;
    [SerializeField] private Image image;
    [SerializeField] private TMP_InputField input;

    private void Awake()
    {
        input.characterLimit = 1;
        input.onSubmit.AddListener(textCheckHandler);
    }

    private void textCheckHandler(string arg0)
    {
        if (arg0 == word.upperCase || arg0 == word.lowerCase)
        {
            image.color = Color.green;
            return;
        }
        image.color = Color.red;
    }
}
