using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string dialog = "...";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WorldManager.Instance.TextPopUp(dialog);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        WorldManager.Instance.TextPopDown();
    }
}
