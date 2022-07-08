using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerIAController : MonoBehaviour
{
    public float speedMovement = 200f;
    public Transform ball;
    private Rigidbody2D myRigidbody;
    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if(Mathf.Abs(transform.position.y - ball.position.y) > 50)
        {
            if (transform.position.y < ball.position.y)
                myRigidbody.velocity = new Vector2(0, 1) * speedMovement;
            else
                myRigidbody.velocity = new Vector2(0, -1) * speedMovement;
        }
        else
        {
            myRigidbody.velocity = Vector2.zero;
        } 
    }
}
