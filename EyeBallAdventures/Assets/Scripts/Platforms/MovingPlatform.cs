using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float leftPoint;
    [SerializeField] private float rightPoint;
    [SerializeField] private float UpperPoint;
    [SerializeField] private float LowerPoint;

    [SerializeField] private bool moveUpAndDown;
    [SerializeField] private bool moveLeftAndRight;

    [SerializeField] private float horiontalSpeed;
    [SerializeField] private float verticalSpeed;
    private bool movingRight = true;
    private bool movingUp = true;
    private Renderer movingPlatformRenderer;

    // Start is called before the first frame update
    private  void Start()
    {
        movingPlatformRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (movingPlatformRenderer.isVisible)
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
            transform.position = new Vector2(transform.position.x, transform.position.y + verticalSpeed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x , transform.position.y - verticalSpeed * Time.fixedDeltaTime);
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
            transform.position = new Vector2(transform.position.x + horiontalSpeed * Time.fixedDeltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - horiontalSpeed * Time.fixedDeltaTime, transform.position.y);
        }
    }

}
