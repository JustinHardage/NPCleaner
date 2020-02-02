using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDoorTrigger : MonoBehaviour
{
    Room parentRoom;

    private void Start()
    {
        parentRoom = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Topdownmovement>();
        parentRoom.PlayerIsIn();
    }
}
