using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePhysics : MonoBehaviour {

	//public static BridgePhysics bridgePhysics;
	public static bool startTriggered = false;
	public static bool endTriggered = false;
	public GameObject baseWater;
	public GameObject solvedWater;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (startTriggered && endTriggered) 
		{
			baseWater.SetActive (false);
			solvedWater.SetActive (true);
		}
			

	}
}
