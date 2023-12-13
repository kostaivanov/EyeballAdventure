using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = player.gameObject.GetComponent<PlayerMovement>();

    }
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.CompareTag("Player"))
        {
            playerMovement.leftMovementButton.enabled = false;
            playerMovement.rightMovementButton.enabled = false;
            playerMovement.jumpButton.enabled = false;

            playerMovement.enabled = false;
        }       
    }

    private void OnTriggerExit2D(Collider2D otherObject)
    {
        if (otherObject.CompareTag("Player"))
        {
            playerMovement.leftMovementButton.enabled = true;
            playerMovement.rightMovementButton.enabled = true;
            playerMovement.jumpButton.enabled = true;

            playerMovement.enabled = true;
        }
    }
}
