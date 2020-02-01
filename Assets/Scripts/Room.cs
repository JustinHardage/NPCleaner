using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Cinemachine.CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        // get player
        // get cinemachine virtual camera

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CloseExits()
    {

    }

    void OpenExits()
    {

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<Topdownmovement>();
        Debug.Log($"player {player}");

        if (player == null) { return; }

        vcam.Follow = this.transform;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        var player = collider.gameObject.GetComponent<Topdownmovement>();

        if (player == null) { return; }

        vcam.Follow = player.transform;
    }


}
