using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    [SerializeField] private float healthPoints;
    [SerializeField] private GameObject dropsEffect;
    [SerializeField] private GameObject pointsEffect;
    private GameObject clone_Drops;
    private GameObject clone_PointsEffect;

    private void Start()
    {
        PermanentFunctions.instance.dropsCollectedTemp = 0;
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.tag == "Player")
        {
            clone_Drops = Instantiate(dropsEffect, this.transform.position, Quaternion.identity);
            clone_PointsEffect = Instantiate(pointsEffect, this.transform.position, Quaternion.identity);
            PlayerHealth playerhealth = otherObject.GetComponent<PlayerHealth>();
            playerhealth.AddHealth(healthPoints);

            Destroy(this.gameObject);
            Destroy(clone_Drops, 0.5f);
            Destroy(clone_PointsEffect, 1.2f);
            PermanentFunctions.instance.dropsCollectedTemp++;
        }
    }
}
