using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PlayerLerpColor
{
    internal IEnumerator LerpColor(PlayerHealth playerHealth, SpriteRenderer objectRenderer, Collider2D playerCollider, float duration, float blinkTime)
    {
        while (duration > 0f && playerHealth != null)
        {
            playerHealth.isBlinking = true;
            duration -= Time.deltaTime;

            //toggle renderer
            objectRenderer.enabled = !objectRenderer.enabled;
            Physics2D.IgnoreLayerCollision(11, 12);

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
        }

        //make sure renderer is enabled when we exit
        if (playerHealth != null)
        {
            objectRenderer.enabled = true;
            playerHealth.isBlinking = false;
        }
        Physics2D.IgnoreLayerCollision(11, 12, false);
    }
}
