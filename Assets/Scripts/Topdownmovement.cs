using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Topdownmovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 5f;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 targetVel = (new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        rb2d.velocity = targetVel * speed * Time.deltaTime;
    }
}