using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] GameObject bagButton;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gameManager.searchBag == false)
        {
            bagButton.SetActive(true);
        }
    }
}
