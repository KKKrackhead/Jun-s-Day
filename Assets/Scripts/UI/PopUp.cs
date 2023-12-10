using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] GameObject popUp;

    bool playerInReach;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInReach = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInReach = false;
        popUp.SetActive(false);
    }

    private void Update()
    {
        if(playerInReach == true && player.interacting == true)
        {
            popUp.SetActive(true);
        }
    }
}
