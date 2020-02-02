using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutDoorTrigger : MonoBehaviour
{
    Room parentRoom;
    public GameObject[] objects;
    public GameObject[] objLocations;
    public int arrayLength;

    private void Start()
    {
        //objects = new GameObject[arrayLength];
       // objLocations = new GameObject[arrayLength];
        parentRoom = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Topdownmovement>();
        parentRoom.PlayerIsIn();
    }
}
