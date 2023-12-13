using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class PlayerHealth : PlayerComponents, IVulnerable<Transform>, IDirectionable<Transform, Vector2>
{
    #region Constants
    private const float lowerFallingBound_Y = -6f;
    private const float decreasePerMinute = 5;
    internal const float pushingForce = 35f;
    #endregion

    #region Serialized Fields
    [SerializeField] protected float fullHealth;
    [SerializeField] protected RestartGame restart;

    [SerializeField] private AudioSource playerAudioSource;
    //[SerializeField] private AudioSource pickDrop;
    //[SerializeField] private AudioSource lifePickUp;

    [SerializeField] private AudioClip hurtSound, pickDropSound, LifePickSound, dyingSound;
    #endregion

    #region booleans
    internal bool fellOffWorld = false;
    private bool healthBarIsActive = false;
    private bool isAlive;
    internal bool isDamaged = false;
    private bool healthBarUIFound;
    #endregion

    internal float currentHealth;
    protected Slider healthSlider;
    protected Animator playerAnimator;
    //private CashCollector playerCash;
    internal bool isBlinking = false;

    private GameObject adMobManager;
    private AdMobController adMobController;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        adMobManager = GameObject.FindGameObjectWithTag("AdMobManager");
        adMobController = adMobManager.GetComponent<AdMobController>();
        
        //if (adMobController.interstitial.IsLoaded())
        //{
        //    adMobController.interstitial.Destroy();
        //}
        adMobController.RequestInterstitial();
        fellOffWorld = false;

        //playerCash = GetComponent<CashCollector>();
        healthBarUIFound = false;
        isAlive = true;
        currentHealth = fullHealth;
        playerAnimator = GetComponent<Animator>();
        //if (GameObject.FindGameObjectWithTag("PlayerHealthBar") != null)
        //{
        //    this.healthSlider = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
        //    healthBarIsActive = true;

        //    healthSlider.maxValue = fullHealth;
        //    healthSlider.value = fullHealth;            
        //}        
    }

    // Update is called once per frame
    private void Update()
    {
        if (healthBarUIFound == false && GameObject.FindGameObjectWithTag("PlayerHealthBar") != null)
        {
            this.healthSlider = GameObject.FindGameObjectWithTag("PlayerHealthBar").GetComponent<Slider>();
            healthBarIsActive = true;

            healthSlider.maxValue = fullHealth;
            healthSlider.value = fullHealth;
        }

        if (this.transform.position.y < lowerFallingBound_Y)
        {                       
            base.playerMovement.enabled = false;
            if (PermanentFunctions.instance.remainingLives >= 0)
            {
                if (isAlive == true && fellOffWorld.Equals(false))
                {
                    playerAudioSource.PlayOneShot(dyingSound);
                }                
                            
                PlayerDies();
                fellOffWorld = true;
            }
            else
            {
                Time.timeScale = 0.0f;
            }
        }

        //if (fellOffWorld)
        //{
        //    if (PermanentFunctions.instance.remainingLives >= 0)
        //    {
        //        PlayerDies();  
        //    }
        //    else
        //    {
        //        Time.timeScale = 0.0f;
        //    }

        //}

        if (healthBarIsActive == true)
        {
            currentHealth -= Time.deltaTime * decreasePerMinute / 5f;
            this.healthSlider.value = this.currentHealth;
        }

        if (this.currentHealth <= 0 && this.isAlive == true)
        {
            //PermanentFunctions.instance.collectedCoinsPerLvl -= playerCash.coins;
            base.playerMovement.enabled = false;
            if (fellOffWorld != true)
            {
                playerAudioSource.PlayOneShot(dyingSound);
            }           

            this.playerAnimator.SetTrigger("isDead");
            this.isAlive = false;

        }
    }

    //private void LateUpdate()
    //{
    //    if (turnDeathAnimation_On)
    //    {
    //        isAlive = false;
    //        //base.playerMovement.enabled = false;
    //        base.playerAnimator.SetTrigger("isDead");
    //        turnDeathAnimation_On = false;
    //    }       
    //}


    internal void PlayLifePickUpSound()
    {
        playerAudioSource.PlayOneShot(LifePickSound);
    }


    internal void AddHealth(float healthPoints)
    {
        playerAudioSource.PlayOneShot(pickDropSound);
        this.currentHealth += healthPoints;

        if (this.currentHealth > this.fullHealth)
        {
            this.currentHealth = this.fullHealth;
        }

        this.healthSlider.value = this.currentHealth;
    } 

    public void TakeDamage(Transform otherObject, float damage, float pushingForce)
    {

        if (damage <= 0)
        {
            return;
        }
        playerAudioSource.PlayOneShot(hurtSound);

        this.currentHealth -= damage;
        this.healthSlider.value = this.currentHealth;

        //if (this.currentHealth <= 0)
        //{
        //    base.playerMovement.enabled = false;
        //    turnDeathAnimation_On = true;

        //    //isAlive = false;
        //    //base.playerMovement.enabled = false;
        //    this.playerAnimator.SetTrigger("isDead");
        //    turnDeathAnimation_On = false;
        //}
    }

    private void FreezePlayer()
    {
        base.playerRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }

    public void PushUpAfterDead()
    {
        base.playerRigidBody.constraints = RigidbodyConstraints2D.None;

        Vector2 pushDirection = new Vector2(0, 1).normalized;
        pushDirection *= pushingForce;
        playerRigidBody.velocity = Vector2.zero;      

        playerRigidBody.AddForce(pushDirection, ForceMode2D.Impulse);
 
        base.playerCollider2D.enabled = false;
        //PlayerDies();
    }

    public void PlayerDies()
    {
        if (PermanentFunctions.instance.remainingLives == 4 || PermanentFunctions.instance.remainingLives == 1)
        {
            adMobController.ShowInterstitialAd();
        }       

        Physics2D.IgnoreLayerCollision(11, 12, false);
        PermanentFunctions.instance.GettingDamagedCount++;
        Destroy(this.gameObject, 2.5f);
        restart.RestartTheGame();
        
    }

    public Vector2 FindDirectionToPush(Transform otherObject)
    {
        Vector2 direction = Vector2.zero;

        if (this.transform.position.x > otherObject.position.x)
        {
            direction = new Vector2(1, 0);
        }

        if (this.transform.position.x < otherObject.position.x)
        {
            direction = new Vector2(-1, 0);
        }

        return direction;
    }
}
