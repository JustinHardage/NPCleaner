using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string dialog = "...";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogPopUp();
    }

    void DialogPopUp()
    {
        // call whatever the UI thing is that we're using
        // populate it with string
    }
}
