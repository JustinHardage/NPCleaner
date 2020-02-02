using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pots : MonoBehaviour {

    public Room parentRoom;
    public bool floating = false;
	public bool isBridge = false;

	public void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.CompareTag ("Water")) 
		{
            Debug.Log("aye");
			floating = true;
			this.gameObject.layer = 13;
			this.gameObject.transform.SetParent (null);
			this.gameObject.AddComponent<Rigidbody2D> ();
			this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;
			this.gameObject.GetComponent<Rigidbody2D> ().AddForce (transform.forward * 400); 


		}

		if (floating)
		{
			if (col.gameObject.CompareTag("Pushable") || col.gameObject.CompareTag("waterEnd"))
			{
				this.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
				this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
				this.gameObject.layer = 11;
				isBridge = true;
			}
		}
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.CompareTag ("StartTrigger"))
			BridgePhysics.startTriggered = true;
		if (col.gameObject.CompareTag ("EndTrigger"))
			BridgePhysics.endTriggered = true;

	}

    public void defaultState()
    {
        this.gameObject.layer = 9;
        this.gameObject.transform.SetParent(null);
        Destroy(this.gameObject.GetComponent<Rigidbody2D>());
        //this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
       // this.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.forward * 400);

    }


}
