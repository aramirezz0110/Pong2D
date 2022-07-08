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
        StartCoroutine(StartBall(true));
    }
    public IEnumerator StartBall(bool startPlayer1=true)
    {
        hitCounter = 0;
        yield return new WaitForSeconds(2);
        if (startPlayer1)
            BallMovement(new Vector2(-1,0));
        else
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
            print("Increasing hit counter");
        }
    }    
}
