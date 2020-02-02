using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public enum RoomState { DEFAULT, ACTIVE, SOLVED };

    public Cinemachine.CinemachineVirtualCamera _vcam;
    public Text _timerText;

    public bool _shouldShutPlayerIn = false;
    public RoomState _roomState = RoomState.ACTIVE;
    public float _startingTime = 0f;

    public float _remainingTime;
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
    void FixedUpdate()
    {
        TickDown();
    }

    private void TickDown()
    {
        if (WorldManager.Instance._currentRoom != this) { return; }
        if (_roomState == RoomState.SOLVED) { return; }
        if (_startingTime <= 0f) { return; }
        if (_remainingTime > 0f)
        {
            _remainingTime -= Time.deltaTime;
        }
        else
        {
            // time up, end game? restart room?
            WorldManager.Instance.TimeOver(this);
            Debug.Log("Time Over");
        }
    }


    public void PlayerIsIn()
    {
        StartRoom();
    }

    public void StartRoom()
    {
        WorldManager.Instance._currentRoom = this;

        if (ShouldClosePlayerIn)
        {
            CloseExits();
        }

        // Initialize room; check if we should start any traps or activate enemies
        if (_roomState == RoomState.ACTIVE && _startingTime > 0f)
        {
            _remainingTime = _startingTime;
        }
    }

    public void LeaveRoom(Topdownmovement player)
    {
        //SetRoomState(RoomState.SOLVED);
        WorldManager.Instance._currentRoom = null;

        if (player == null) { return; }

        _vcam.Follow = player.transform;
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

    public string TimerReadout()
    {
        if (_roomState == RoomState.SOLVED) {
            return "✔️";
        }
        else if (_startingTime == 0f)
        {
            return "?";
        }
        else if (_remainingTime > 0f)
        {
            return $"00:{_remainingTime.ToString("00")}";
        }
        else { return "oh nooo"; }
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

        

        LeaveRoom(player);

        OpenExits();    // just in case???
    }


}
