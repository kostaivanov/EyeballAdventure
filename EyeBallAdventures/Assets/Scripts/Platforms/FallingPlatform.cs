using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.8f;
    private const float massIncrease = 5f;
    private const float fallingTime = 1f;

    private Rigidbody2D platformRigidBody;
    [SerializeField] private Collider2D platformCollider;
    private GameObject child;
    private bool childsExist;
    private void Start()
    {
        platformRigidBody = GetComponent<Rigidbody2D>();
        childsExist = false;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "PlayerTrigger")
        {
            SpriteRenderer playerRenderer = otherObject.GetComponentInParent<SpriteRenderer>();

            if (CheckIfChildsExist() == true)
            {
                child = this.gameObject.transform.GetChild(0).gameObject;
            }

            StartCoroutine(FallAfterDelay(delayTime, playerRenderer));
        }
    }

    IEnumerator FallAfterDelay(float delay, SpriteRenderer playerRenderer)
    {
        yield return new WaitForSeconds(delay);
        platformRigidBody.isKinematic = false;

        platformRigidBody.gravityScale = massIncrease;
        platformCollider.enabled = false;

        if (playerRenderer.enabled == false)
        {
            playerRenderer.enabled = true;
        }

        yield return new WaitForSeconds(fallingTime);
        SpriteRenderer platformRenderer = GetComponent<SpriteRenderer>();
        platformRenderer.enabled = false;

        if (childsExist == true)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
        }
        
        platformRigidBody.bodyType = RigidbodyType2D.Static;
    }

    private bool CheckIfChildsExist()
    {
        if (this.gameObject.transform.childCount > 0)
        {
            childsExist = true;
        }
        return childsExist;
    }
}
