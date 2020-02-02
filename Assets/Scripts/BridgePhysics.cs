using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePhysics : MonoBehaviour {

	//public static BridgePhysics bridgePhysics;
	public static bool startTriggered = false;
	public static bool endTriggered = false;
    public static bool startTriggered2 = false;
    public static bool endTriggered2 = false;
	public GameObject baseWater;
    public GameObject solvedWater;
    public Room parentRoom;
    public Room parentRoom2;
    public GameObject baseWater2;
    public GameObject solvedWater2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startTriggered && endTriggered) 
		{
			baseWater.SetActive (false);
			solvedWater.SetActive (true);
            parentRoom.SetRoomState(Room.RoomState.SOLVED);
        }
        if (startTriggered2 && endTriggered2)
        {
            baseWater2.SetActive(false);
            solvedWater2.SetActive(true);
            parentRoom2.SetRoomState(Room.RoomState.SOLVED);
        }


    }
}
