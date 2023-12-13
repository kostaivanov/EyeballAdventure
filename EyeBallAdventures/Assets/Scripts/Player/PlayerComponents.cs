using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class PlayerComponents : MonoBehaviour
{


    #region Unity Components
    protected Rigidbody2D playerRigidBody;
    protected Collider2D playerCollider2D;
    //protected Animator playerAnimator;
    protected PlayerMovement playerMovement;
    protected PlayerHealth playerHealth;
    protected SpriteRenderer playerSprite;
    #endregion

    internal LayerMask groundLayer;
    internal PlayerState state = PlayerState.idle;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playerCollider2D = GetComponent<Collider2D>();
        //playerAnimator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        groundLayer = LayerMask.GetMask("GroundLayer");
        playerSprite = GetComponent<SpriteRenderer>();
        playerHealth = GetComponent<PlayerHealth>();
    }   
}
