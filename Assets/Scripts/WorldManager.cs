using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldManager : MonoBehaviour
{
    // singleton
    private static WorldManager _instance;
    public static WorldManager Instance => _instance ?? (_instance = FindObjectOfType<WorldManager>());

    // inspector references
    public Room _currentRoom;

    // UI references
    public Text _timerText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _timerText.text = _currentRoom?.TimerReadout() ?? "No Timer";
    }

    public void TimeOver(Room callingRoom)
    {
        if (_currentRoom != callingRoom) { return; }


    }
}
