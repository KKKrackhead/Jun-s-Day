using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlaces : MonoBehaviour
{
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;
    [SerializeField] private GameObject classroom;
    [SerializeField] private GameObject ariel;
    private GameObject player;
    GameManager gameManager;

    FadeScreen UIFade;

    bool CheckHomework;

    private void Start()
    {
        player = GameObject.Find("Player");
        UIFade = GameObject.Find("UIManager").GetComponent<FadeScreen>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIFade.CtB();
            player.transform.position = end.transform.position;
            ChangePlace();
            UIFade.BtC();
        }
    }

    private void ChangePlace()
    {
        if (player.GetComponent<PlayerController>().currentPlace == Place.RoomMorning) player.GetComponent<PlayerController>().currentPlace = Place.Class;
        else if (player.GetComponent<PlayerController>().currentPlace == Place.Class && gameManager.homeworkDone == false) GoToAriel();
        else if (player.GetComponent<PlayerController>().currentPlace == Place.Class) player.GetComponent<PlayerController>().currentPlace = Place.Alley;
        else if (player.GetComponent<PlayerController>().currentPlace == Place.Alley) player.GetComponent<PlayerController>().currentPlace = Place.RoomNight;

        Debug.Log("Player is currently in " + player.GetComponent<PlayerController>().currentPlace);
    }

    private void GoToAriel()
    {
        player.transform.position = ariel.transform.position;
        player.GetComponent<PlayerController>().currentPlace = Place.Hallway;
    }

    private void Update()
    {
        if (player.GetComponent<PlayerController>().currentPlace == Place.RoomMorning) StartCoroutine(RoomTimer());
    }

    private IEnumerator RoomTimer()
    {
        yield return new WaitForSecondsRealtime(180f);
        player.transform.position = classroom.transform.position;
        ChangePlace();
    }
}