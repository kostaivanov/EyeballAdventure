using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class SpikeDealsDamage : EnemyComponents, IDamageCauseable
{
    //private const float disablePlayerAfterHitTime = 0.15f;

    public float damage => 10f;
    public float pushForce => 30f;
    private float nextDamage;
    [SerializeField] private float damageRate;
    //private PlayerMovement playerController;
    //private bool isCoroutineExecuting = false;
    private PlayerHealth playerHealth;
    //private bool isBlinking = false;

    [SerializeField] private GameObject player;
    private Collider2D playerCollider;
    private SpriteRenderer playerRenderer;
    private PlayerLerpColor playerBlinking;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        nextDamage = 0f;
        playerHealth = player.GetComponent<PlayerHealth>();
        playerRenderer = player.GetComponent<SpriteRenderer>();
        playerCollider = player.gameObject.GetComponent<Collider2D>();
        playerBlinking = new PlayerLerpColor();
        
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {       
        if (otherObject.tag == "Player" && nextDamage < Time.time && playerHealth.isBlinking == false)
        {
            playerHealth = player.GetComponent<PlayerHealth>();

            if (playerHealth.currentHealth > 0 && playerHealth.isBlinking == false)
            {                
                playerHealth.TakeDamage(this.transform, this.damage, this.pushForce);

                if (playerHealth.currentHealth > 0 && this.player != null && this.gameObject != null)
                {
                    StartCoroutine(playerBlinking.LerpColor(playerHealth, playerRenderer, playerCollider, damageRate, 0.06f));
                    PushVertically(otherObject.transform);   
                }
                
                nextDamage = Time.time + damageRate;
            }

            else
            {                
                //Physics2D.IgnoreCollision(otherObject.gameObject.GetComponent<Collider2D>(), base.enemyCollider);
                Physics2D.IgnoreLayerCollision(11, 12);
            }

            //StartCoroutine(DelayMovement(otherObject.transform));

            PermanentFunctions.instance.GettingDamagedCount++;
        }      
    }

    private void OnTriggerStay2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player" && this.gameObject.tag == "Enemy")
        {
            playerHealth = otherObject.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth.currentHealth < 0)
            {
                //Physics2D.IgnoreCollision(otherObject.gameObject.GetComponent<Collider2D>(), base.enemyCollider);
                Physics2D.IgnoreLayerCollision(11, 12);
            }

            if (playerHealth.currentHealth > 0 && playerHealth.isBlinking == false)
            {
                playerHealth.TakeDamage(this.transform, this.damage, this.pushForce);

                if (playerHealth.currentHealth > 0 && this.player != null && this.gameObject != null)
                {
                    StartCoroutine(playerBlinking.LerpColor(playerHealth, playerRenderer, playerCollider, damageRate, 0.06f));
                    PushVertically(otherObject.transform);
                }

                nextDamage = Time.time + damageRate;
            }
        }
    }

    //IEnumerator LerpColor(SpriteRenderer objectRenderer, Collider2D playerCollider, float duration, float blinkTime)
    //{
    //    while (duration > 0f && this.player != null)
    //    {
    //        playerHealth.isBlinking = true;
    //        duration -= Time.deltaTime;

    //        //toggle renderer
    //        objectRenderer.enabled = !objectRenderer.enabled;
    //        Physics2D.IgnoreLayerCollision(11, 12);

    //        //wait for a bit
    //        yield return new WaitForSeconds(blinkTime);          
    //    }

    //    //make sure renderer is enabled when we exit
    //    if (this.player != null)
    //    {
    //        objectRenderer.enabled = true;
    //        playerHealth.isBlinking = false;            
    //    }
    //    Physics2D.IgnoreLayerCollision(11, 12, false);
    //}

    private void PushVertically(Transform otherObject)
    {
        Vector3 pushDirection = Vector3.zero;

        if (this.transform.position.x < otherObject.transform.position.x)
        {
            pushDirection = Quaternion.AngleAxis(70f, Vector3.forward) * Vector3.right;
        }
        else if (this.transform.position.x > otherObject.transform.position.x)
        {
            pushDirection = Quaternion.AngleAxis(70f, Vector3.back) * Vector3.left;
        }

        pushDirection *= pushForce;
        Rigidbody2D pushRigidBody = otherObject.gameObject.GetComponent<Rigidbody2D>();
        pushRigidBody.velocity = Vector2.zero;
        pushRigidBody.AddForce(pushDirection, ForceMode2D.Impulse);
    }

    //private IEnumerator DelayMovement(Transform otherObject)
    //{
    //    if (isCoroutineExecuting)
    //        yield break;

    //    isCoroutineExecuting = true;

    //    playerController = otherObject.gameObject.GetComponent<PlayerMovement>();
    //    playerController.enabled = false;

    //    yield return new WaitForSeconds(disablePlayerAfterHitTime);

    //    playerController.enabled = true;

    //    isCoroutineExecuting = false;
    //}

}
