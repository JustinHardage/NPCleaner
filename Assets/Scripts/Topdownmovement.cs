using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Topdownmovement : MonoBehaviour
{
	public GameObject[] items;
    public Rigidbody2D rb2d;
	private float baseSpeed;
    public float speed = 5f;

	public bool pushing = false;
	public bool grabbing = false;
	public bool holdingBlock;

	public GameObject heldBlock;
    
    // Use this for initialization
    void Start()
    {
		baseSpeed = speed;
		//heldBlock = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetVel = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        rb2d.velocity = targetVel * speed * Time.deltaTime;
    }

	public void Update()
	{

		if (Input.GetKey (KeyCode.Z)) 
		{
			pushing = true;
			grabbing = true;

		} 

		if (Input.GetKeyUp(KeyCode.Z))
		{
			pushing = false;
			grabbing = false;
			if (heldBlock != null)
				heldBlock.transform.SetParent (null);
			holdingBlock = false;
			speed = baseSpeed;
		}
			
	}

	public void OnCollisionStay2D(Collision2D col)
	{
		//Debug.Log ("push space");
		if (col.gameObject.CompareTag ("Pushable")) 
		{
			if (pushing && holdingBlock == false) 
			{
				heldBlock = col.gameObject;
				//Debug.Log ("pushing!");
				speed = (speed / 3);
				col.gameObject.transform.SetParent (this.gameObject.transform);
				holdingBlock = true;
			} 

		}

		if (col.gameObject.CompareTag ("Grabbable")) 
		{
			if (grabbing && holdingBlock == false) 
			{
				items [2] = col.gameObject;
				col.gameObject.SetActive (false);
			} 

		}
				
	}

}
