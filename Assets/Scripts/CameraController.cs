using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private CinemachineVirtualCamera vCam;
    [SerializeField] private PolygonCollider2D[] confiners;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        vCam = GameObject.Find("VCam").GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (vCam.gameObject.activeInHierarchy == true)
        {
            if (player.currentPlace == Place.RoomMorning)
            {
                Collider2D newConfiner = confiners[0];
                vCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newConfiner;
            }
            else if (player.currentPlace == Place.Class)
            {
                Collider2D newConfiner = confiners[1];

                vCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newConfiner;
            }
            else if (player.currentPlace == Place.Hallway)
            {
                Collider2D newConfiner = confiners[2];

                vCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newConfiner;
            }
            else if (player.currentPlace == Place.Alley)
            {
                Collider2D newConfiner = confiners[3];

                vCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newConfiner;
            }
            else if (player.currentPlace == Place.RoomNight)
            {
                Collider2D newConfiner = confiners[4];

                vCam.GetComponent<CinemachineConfiner>().m_BoundingShape2D = newConfiner;
            }
        }
        else Debug.LogError("no vcam found");
    }
}