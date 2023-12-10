using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] GameObject followCam;

    public Place currentPlace;

    public bool interacting;

    private void Awake()
    {
        currentPlace = Place.RoomMorning;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interacting = true;
        }
        else interacting = false;
    }
}

public enum Place{
    RoomMorning,
    Class,
    School,
    Alley,
    RoomNight,
    Hallway,
    None
}