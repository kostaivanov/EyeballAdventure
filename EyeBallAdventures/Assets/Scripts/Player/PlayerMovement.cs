using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
internal class PlayerMovement : PlayerComponents
{
    #region Constants
    private const float minimumVelocity_X = 1f;
    private const float minimumFallingVelocity_Y = -2f;
    private const float groundCheckRadius = 0.1f;
    #endregion

    #region Serialized Fields
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField]
    private AudioClip jumpSound;

    [SerializeField] internal float speed;
    [SerializeField] internal float jumpHeight;
    [SerializeField] Transform playerGroundCheck;
    #endregion   

    #region booleans
    internal bool moveKeyIsPressed;    
    public bool isOnTheGround;
    private bool canDoubleJump = false;
    private bool firstJumpCompleted;
    private bool jumpPressed;
    private bool playerHasJumped = false;
    #endregion

    private float zeroSpeed = 0;
    private float direction;
    internal MovementLeftHandler leftMovementButton;
    internal MovementRightHandler rightMovementButton;
    internal JumpHandler jumpButton;
    private float extrHeightText = 0.1f;
    private Color rayColor;
    protected Animator playerAnimator;
    private bool gameUIFound;
    

    private void Awake()
    {
        //if (GameObject.FindGameObjectWithTag("RightButton") != null)
        //{
        //    leftMovementButton = GameObject.FindGameObjectWithTag("LeftButton").GetComponent<MovementHandler>();
        //    rightMovementButton = GameObject.FindGameObjectWithTag("RightButton").GetComponent<MovementHandler>();
        //    jumpButton = GameObject.FindGameObjectWithTag("JumpButton").GetComponent<JumpHandler>();
        //}
    }


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerAnimator = GetComponent<Animator>();
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0;
        gameUIFound = false;

        moveKeyIsPressed = false;
        transform.position = PermanentFunctions.instance.lastCheckPointPosition;
    }

    // Update is called once per frame
    protected void Update()
    {        
        if (gameUIFound == false && GameObject.FindGameObjectWithTag("GameUI") != null)
        {
            leftMovementButton = GameObject.FindGameObjectWithTag("LeftButton").GetComponent<MovementLeftHandler>();
            rightMovementButton = GameObject.FindGameObjectWithTag("RightButton").GetComponent<MovementRightHandler>();
            leftMovementButton.moveButtonPressed = false;
            rightMovementButton.moveButtonPressed = false;
            jumpButton = GameObject.FindGameObjectWithTag("JumpButton").GetComponent<JumpHandler>();
            gameUIFound = true;
            
        }

        if (leftMovementButton != null && rightMovementButton != null)
        {
            if (Input.anyKey || leftMovementButton.moveButtonPressed == true || rightMovementButton.moveButtonPressed == true)
            {
                direction = FindDirection();
               
                moveKeyIsPressed = true;
            }
        }
        if (jumpButton != null )
        {
            if (jumpButton.jumpButtonClicked || Input.GetKeyDown(KeyCode.Space))
            {

                jumpButton.jumpButtonClicked = false;

                jumpPressed = true;
              
            }
        }

        if (playerHasJumped == true)
        {
            playerAudioSource.PlayOneShot(jumpSound);
            playerHasJumped = false;
        }
        //if (CheckIfIsGrounded())
        //{
        //    rayColor = Color.green;
        //}
        //else
        //{
        //    rayColor = Color.red;
        //}

        //Debug.DrawRay(base.playerCollider2D.bounds.center + new Vector3(base.playerCollider2D.bounds.extents.x, 0), Vector2.down * (base.playerCollider2D.bounds.extents.y + extrHeightText), rayColor);
        //Debug.DrawRay(base.playerCollider2D.bounds.center - new Vector3(base.playerCollider2D.bounds.extents.x, 0), Vector2.down * (base.playerCollider2D.bounds.extents.y + extrHeightText), rayColor);
        //Debug.DrawRay(base.playerCollider2D.bounds.center - new Vector3(base.playerCollider2D.bounds.extents.x, base.playerCollider2D.bounds.extents.y + extrHeightText), Vector2.right * (base.playerCollider2D.bounds.extents.x), rayColor);
        //Debug.Log(hit.collider);
        if (moveKeyIsPressed)
        {
            Move(direction);
            moveKeyIsPressed = false;
        }

        if (jumpPressed)
        {
            Jump();
            jumpPressed = false;
        }
    }

    private void LateUpdate()
    {
        this.AnimationStateSwitch();
        this.playerAnimator.SetInteger("state", (int)state);
    }

    private float FindDirection()
    {
        if (leftMovementButton.moveButtonPressed == true)
        {
            direction = -1f;
        }
        else if (rightMovementButton.moveButtonPressed == true)
        {
            direction = 1f;
        }
        else
        {
            direction = Input.GetAxisRaw("Horizontal");
        }

        return direction;
    }

    private void Move(float direction)
    {
        if (leftMovementButton != null)
        {
            if (direction < 0)
            {
                MoveLeft(speed);
            }
        }

        if (rightMovementButton != null)
        {
            if (direction > 0)
            {
                MoveRight(speed);
            }
        }

        CheckIfIsGrounded();
    }

    internal bool CheckIfIsGrounded()
    {        
        RaycastHit2D rayCastHit = Physics2D.BoxCast(base.playerCollider2D.bounds.center, base.playerCollider2D.bounds.size, 0f, Vector2.down, extrHeightText, base.groundLayer);       
        
        return rayCastHit.collider != null;
    }

    public void MoveLeft(float speed)
    {
        playerRigidBody.velocity = new Vector2(-speed, playerRigidBody.velocity.y);
        this.transform.localScale = new Vector2(-1, 1);
    }

    public void MoveRight(float speed)
    {
        playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
        this.transform.localScale = new Vector2(1, 1);
    }

  

    public void Jump()
    {
        
        if (CheckIfIsGrounded())
        {
            canDoubleJump = true;
            
        }
        
        if (CheckIfIsGrounded())
        {
            playerHasJumped = true;
            //jumpSound.Play();
            playerRigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            playerRigidBody.velocity = new Vector3(0, Mathf.Clamp(playerRigidBody.velocity.y, 0, 18), 0);
            firstJumpCompleted = true;
        }

        else
        {
            if (firstJumpCompleted == true)
            {
                if (canDoubleJump == true)
                {
                    playerHasJumped = true;
                    //jumpSound.Play();
                    playerRigidBody.AddForce(Vector2.up * jumpHeight * 1.2f, ForceMode2D.Impulse);
                    playerRigidBody.velocity = new Vector3(0, Mathf.Clamp(playerRigidBody.velocity.y, 0, 18), 0);
                    canDoubleJump = false;
                    firstJumpCompleted = false;
                }
            }
        }

        //this.state = PlayerState.jumping;


    }

    private void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.transform.tag == "MovingPlatform")
        {
            float platformHalfHeight = otherObject.collider.bounds.size.y / 2;
            if (this.transform.position.y > otherObject.transform.position.y + platformHalfHeight)
            {
                this.transform.parent = otherObject.transform;
            }
           
        }
    }

    private void OnCollisionStay2D(Collision2D otherObject)
    {       
        if (otherObject.transform.tag == "MovingPlatform")
        {
            float platformHalfHeight = otherObject.collider.bounds.size.y / 2;
            if (this.transform.position.y > otherObject.transform.position.y + platformHalfHeight)
            {
                this.transform.parent = otherObject.transform;
            }
            else
            {
                this.transform.parent = null;
            }

        }
    }

    private void OnCollisionExit2D(Collision2D otherObject)
    {
        if (otherObject.transform.tag == "MovingPlatform")
        {
            this.transform.parent = null;
        }
    }

    protected void AnimationStateSwitch()
    {
        if (playerRigidBody.velocity.y > 1f && CheckIfIsGrounded() != true)
        {
            this.state = PlayerState.jumping;
            
        }

        else if (state == PlayerState.jumping)
        {
            if (playerRigidBody.velocity.y == 0 || CheckIfIsGrounded() == true)
            {
                state = PlayerState.idle;
            }
        }

        else if (state == PlayerState.jumping)
        {

            if (playerRigidBody.velocity.y < minimumFallingVelocity_Y)
            {
                state = PlayerState.falling;
            }
        }

        else if (state == PlayerState.falling)
        {
            if (this.playerCollider2D.IsTouchingLayers(groundLayer))
            {
                state = PlayerState.idle;
            }
        }

        else if (Input.anyKey && Mathf.Abs(playerRigidBody.velocity.x) > minimumVelocity_X && CheckIfIsGrounded() == true)
        {
            state = PlayerState.moving;
        }

        else
        {
            state = PlayerState.idle;
        }

        if (playerRigidBody.velocity.y < minimumFallingVelocity_Y)
        {
            state = PlayerState.falling;
        }
    }
}
