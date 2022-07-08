using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D),typeof(BoxCollider2D))]
public class BallMovementController : MonoBehaviour
{
    public float speedMovement = 400f;
    public float speedMultiplierByHit=50f;
    public float speedMultiplierMax=1000f;

    private int hitCounter;
    private Rigidbody2D myRigidbody2D;

    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myRigidbody2D.gravityScale = 0;
        StartCoroutine(StartBall(PlayerType.Player1));
    }
    public IEnumerator StartBall(PlayerType playerType)
    {
        hitCounter = 0;
        SetBallPosition(playerType);
        yield return new WaitForSeconds(2);

        if (playerType == PlayerType.Player1)
            BallMovement(new Vector2(-1,0));
        else if (playerType == PlayerType.Player2)
            BallMovement(new Vector2(1,0));
        
    }
    public void BallMovement(Vector2 dir)
    {
        dir = dir.normalized;
        float speed = speedMovement + hitCounter * speedMultiplierByHit;
        myRigidbody2D.velocity = dir * speed;
    }
    public void IncreaseHitCounter()
    {
        if(hitCounter * speedMultiplierByHit <= speedMultiplierMax)
        {
            hitCounter++;            
        }
    }
    private void SetBallPosition(PlayerType playerType)
    {
        myRigidbody2D.velocity = new Vector2(0, 0);
        if(playerType == PlayerType.Player1)
        {
            gameObject.transform.localPosition = new Vector3(-100, 0, 0);

        }
        else if(playerType == PlayerType.Player2)
        {
            gameObject.transform.localPosition = new Vector3(100, 0, 0);
        }
    }
}
