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
        if (collision.gameObject.CompareTag("Player"))
        {
            parentRoom.PlayerIsIn();
            if (arrayLength > 0 && parentRoom._roomState != Room.RoomState.SOLVED)
            {
                for (int i = 0; i < arrayLength; i++)
                {
                    objects[i].transform.position = objLocations[i].transform.position;
                    objects[i].GetComponent<Pots>().defaultState();
                }
            }
        }
    }
}
