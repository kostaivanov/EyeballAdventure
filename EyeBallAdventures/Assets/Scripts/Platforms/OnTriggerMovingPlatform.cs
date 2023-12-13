using UnityEngine;

public class OnTriggerMovingPlatform : MonoBehaviour
{
    [SerializeField]
    private float leftPoint, rightPoint, UpperPoint, LowerPoint;

    [SerializeField]
    private bool moveUpAndDown, moveLeftAndRight;

    [SerializeField]
    private float horiontalSpeed, verticalSpeed;

    private bool movingRight = true;
    private bool movingUp = true;


    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.tag == "PlayerTrigger")
        {
            if (moveLeftAndRight == true)
            {
                MoveLeftAndRight();
            }

            if (moveUpAndDown == true)
            {
                MoveUpAndDown();

            }
        }
    }

    private void MoveUpAndDown()
    {
        if (transform.position.y > UpperPoint)
        {
            movingUp = false;
        }
        if (transform.position.y < LowerPoint)
        {
            movingUp = true;
        }

        if (movingUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + verticalSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - verticalSpeed * Time.deltaTime);
        }
    }

    private void MoveLeftAndRight()
    {
        if (transform.position.x > rightPoint)
        {
            movingRight = false;
        }
        if (transform.position.x < leftPoint)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + horiontalSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - horiontalSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
