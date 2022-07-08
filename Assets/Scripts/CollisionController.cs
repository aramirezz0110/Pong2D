using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BallMovementController))]
public class CollisionController : MonoBehaviour
{
    private BallMovementController ballMovementController;
    private RaquetController raquetController;
    private Vector3 ballPosition;
    private Vector3 raquetPosition;
    private float raquetHeight;
    private float xPosition;
    private float yPosition;
    private void Start()
    {
        ballMovementController = GetComponent<BallMovementController>();
    }
    private void RicochetWithRaquet(Collision2D collision)
    {
        ballPosition = transform.position;
        raquetPosition = collision.gameObject.transform.position;
        raquetHeight = collision.collider.bounds.size.y;
                
        raquetController = collision.gameObject.GetComponent<RaquetController>();
        if (raquetController)
        {
            if (raquetController.playerType == PlayerType.Player1)
                xPosition = 1;
            else if (raquetController.playerType == PlayerType.Player2)
                xPosition = -1;
        }

        yPosition = (ballPosition.y - raquetPosition.y) / raquetHeight;
        ballMovementController.IncreaseHitCounter();
        ballMovementController.BallMovement(new Vector2(xPosition,yPosition));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == GameTags.Player)
        {
            RicochetWithRaquet(collision);
        }
        else if(collision.gameObject.tag == GameTags.LeftWall)
        {
            print("Left wall hit");
            ScoreController.Instance.SetPointToPlayer(PlayerType.Player2);
        }
        else if(collision.gameObject.tag == GameTags.RightWall)
        {
            print("Right wall hit");
            ScoreController.Instance.SetPointToPlayer(PlayerType.Player1);
        }
    }
}
