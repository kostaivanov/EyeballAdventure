using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    [SerializeField] private float leftPoint;
    [SerializeField] private float rightPoint;

    [SerializeField] private float speed;
    [SerializeField] private bool moveLeftAndRight;
    private bool movingRight;
    private Renderer movingPlatformRenderer;

    private void Start()
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
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            transform.Rotate(Vector3.back, Time.fixedDeltaTime * 180, Space.Self);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
            transform.Rotate(Vector3.forward, Time.fixedDeltaTime * 180, Space.Self);
        }
    }
}
