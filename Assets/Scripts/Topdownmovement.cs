using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Topdownmovement : MonoBehaviour
{
    public Animator _animator;
	public GameObject[] items;
    public Rigidbody2D rb2d;
	private float baseSpeed;
    public float speed = 5f;

	public bool pushing = false;
	public bool grabbing = false;
	public bool holdingBlock;

	public GameObject heldBlock;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
		baseSpeed = speed;
		//heldBlock = null;
    }

    void FixedUpdate()
    {
        Vector2 targetVel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb2d.velocity = targetVel * speed * Time.deltaTime;
        _animator.SetFloat("speedX", targetVel.x);
        _animator.SetFloat("speedY", targetVel.y);
        _animator.SetBool("moving", targetVel.magnitude > 0.01f);
    }

	public void Update()
	{
		//if (Input.GetKey (KeyCode.Z))
        if (Input.GetButton("Grab"))
		{
			pushing = true;
			grabbing = true;
		} 

		//if (Input.GetKeyUp(KeyCode.Z))
        if (Input.GetButtonUp("Grab"))
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
