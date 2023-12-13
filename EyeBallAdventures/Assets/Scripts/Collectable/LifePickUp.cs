using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifePickUp : MonoBehaviour
{
    private const int lifePickUpPoints = 50;
    //[SerializeField] private GameObject dropsEffect;
    //private GameObject clone;
    TextMeshProUGUI playerLivesCountText;
    [SerializeField] private GameObject pointsEffect;
    private GameObject clone_PointsEffect;
    

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            clone_PointsEffect = Instantiate(pointsEffect, this.transform.position, Quaternion.identity);
            this.playerLivesCountText = GameObject.FindGameObjectWithTag("PlayerLives").GetComponent<TextMeshProUGUI>();
            //clone = Instantiate(dropsEffect, this.transform.position, Quaternion.identity);            
            PlayerHealth playerhealth = otherObject.GetComponent<PlayerHealth>();
            playerhealth.PlayLifePickUpSound();
            PermanentFunctions.instance.lifePickUpPoints += lifePickUpPoints;

            Destroy(this.gameObject);
            Destroy(clone_PointsEffect, 1.2f);
            //Destroy(clone, 0.5f);
            PermanentFunctions.instance.remainingLives++;
            this.playerLivesCountText.text = PermanentFunctions.instance.remainingLives.ToString();
        }
    }
}
