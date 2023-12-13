using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingDownArea : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private float playerConstantSpeed;
    private PlayerMovement playerMovement;
    private float playerReducedSpeed = 2.5f;



    private void Start()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        playerConstantSpeed = playerMovement.speed;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMovement.speed = playerReducedSpeed;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.speed = playerConstantSpeed;
    }
}
