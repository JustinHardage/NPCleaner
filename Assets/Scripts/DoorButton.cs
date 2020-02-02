using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Room parentRoom;
    public bool hasBeenPressed;
    

    // Start is called before the first frame update
    void Start()
    {
        parentRoom = GetComponentInParent<Room>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasBeenPressed) { return; }

        hasBeenPressed = true;
        parentRoom.roomButtons += 1;
        if (parentRoom.roomButtons == parentRoom.maxRoomButtons)
            parentRoom.SetRoomState(Room.RoomState.SOLVED);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (parentRoom.maxRoomButtons > 1)
        {
            hasBeenPressed = false;
            parentRoom.roomButtons -= 1;
        }
    }
}
