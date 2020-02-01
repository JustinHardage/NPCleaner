using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public enum RoomState { DEFAULT, ACTIVE, SOLVED };

    public Cinemachine.CinemachineVirtualCamera _vcam;
    public bool _shouldShutPlayerIn = false;
    public RoomState _roomState = RoomState.ACTIVE;
    public float _startingTime = 0f;

    float _remainingTime;
    bool _doorsClosed = false;
    Door[] _doors;

    public bool ShouldClosePlayerIn => _shouldShutPlayerIn && _roomState == RoomState.ACTIVE;

    // Start is called before the first frame update
    void Start()
    {
        // get player
        // get cinemachine virtual camera
        _vcam = FindObjectOfType<Cinemachine.CinemachineVirtualCamera>();
        _doors = GetComponentsInChildren<Door>(true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerIsIn()
    {
        if (ShouldClosePlayerIn)
        {
            CloseExits();
        }

        // Initialize room; check if we should start any traps or activate enemies
    }

    void CloseExits()
    {
        if (_doorsClosed) { return; }

        _doorsClosed = true;
        foreach (var door in _doors) { door.gameObject.SetActive(true); }
    }

    void OpenExits()
    {
        if (!_doorsClosed) { return; }

        _doorsClosed = false;
        foreach (var door in _doors) { door.gameObject.SetActive(false); }
    }

    public void SetRoomState(RoomState state)
    {
        if (state == RoomState.SOLVED)
        {
            OpenExits();
        }

        _roomState = state;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<Topdownmovement>();

        if (player == null) { return; }

        _vcam.Follow = this.transform;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<Topdownmovement>();

        if (player == null) { return; }

        _vcam.Follow = player.transform;

        OpenExits();
    }


}
