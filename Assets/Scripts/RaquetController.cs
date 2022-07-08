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
    private Vector3 startPosition;
    private void Start()
    {
        myRigigbody2D = GetComponent<Rigidbody2D>();
        startPosition = gameObject.transform.position;
    }
    private void FixedUpdate()
    {
        Movement();        
    }
    private void Movement()
    {
        if(GameManager.Instance.gameMode == GameMode.PvP)
        {
            if (playerType == PlayerType.Player1)
                inputValue = Input.GetAxisRaw(PlayerAxis.Player1);
            else if (playerType == PlayerType.Player2)
                inputValue = Input.GetAxisRaw(PlayerAxis.Player2);

            myRigigbody2D.velocity = new Vector3(0, inputValue) * speedMovement;
        }
        if(GameManager.Instance.gameMode == GameMode.PvM)
        {
            if (playerType == PlayerType.Player1)
            {
                inputValue = Input.GetAxisRaw(PlayerAxis.Player1);
                myRigigbody2D.velocity = new Vector3(0, inputValue) * speedMovement;
            }                            
        }        
    }
    public void RestoreStartPosition()
    {
        gameObject.transform.position = startPosition;
    }
}
