using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class RaquetController : MonoBehaviour
{
    public PlayerType playerType;
    public float speedMovement=200f;

    private float inputValue;
    private Rigidbody2D myRigigbody2D;

    private void Start()
    {
        myRigigbody2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Movement();        
    }
    private void Movement()
    {
        if (playerType == PlayerType.Player1)
            inputValue = Input.GetAxisRaw(PlayerAxis.Player1);
        else if(playerType == PlayerType.Player2)
            inputValue = Input.GetAxisRaw(PlayerAxis.Player2);

        myRigigbody2D.velocity = new Vector3(0, inputValue) * speedMovement;
    }
}
