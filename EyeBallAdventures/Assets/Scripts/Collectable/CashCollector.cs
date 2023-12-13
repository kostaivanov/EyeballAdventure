using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

internal class CashCollector : MonoBehaviour
{
    internal int coins = 0;
    internal TextMeshProUGUI coinsText;
    [SerializeField] private AudioSource playerAudioSource;
    [SerializeField] private GameObject starsEffect;
    [SerializeField] private GameObject pointEffect;
    [SerializeField]
    private AudioClip coinSound;

    private GameObject clone_Stars;
    private GameObject clone_Points;
    private bool coinsCounterUIFound;
    private void Start()
    {
        coinsCounterUIFound = false;
        coinsText = GetComponent<TextMeshProUGUI>();
        //if (GameObject.FindGameObjectWithTag("CoinsCounterText") != null)
        //{
        //    this.coinsText = GameObject.FindGameObjectWithTag("CoinsCounterText").transform.GetComponent<TextMeshProUGUI>();
        //    coins = 0;
        //    PermanentFunctions.instance.collectedCoinsTemp = 0;
        //    coinsText.text = coins.ToString();
        //}
    }

    private void Update()
    {
        if (coinsCounterUIFound == false && GameObject.FindGameObjectWithTag("CoinsCounterText") != null)
        {
            this.coinsText = GameObject.FindGameObjectWithTag("CoinsCounterText").transform.GetComponent<TextMeshProUGUI>();
            coins = 0;
            PermanentFunctions.instance.collectedCoinsTemp = 0;
            coinsText.text = coins.ToString();
            coinsCounterUIFound = true;
            
        }  
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (coinsCounterUIFound == true && otherObject.CompareTag("Money"))
        {
            clone_Stars = Instantiate(starsEffect, otherObject.transform.position, Quaternion.identity);
            clone_Points = Instantiate(pointEffect, otherObject.transform.position, Quaternion.identity);

            //    if (coins == 15)
            //    {
            //        PermanentFunctions.instance.remainingLives++;
            //        remainingLivesText.text = PermanentFunctions.instance.remainingLives.ToString();
            //        coins -= 5;
            //    }


            Destroy(otherObject.gameObject);

            playerAudioSource.PlayOneShot(coinSound);
            coins += 1;
            PermanentFunctions.instance.collectedCoinsTemp++;
            coinsText.text = coins.ToString();
            Destroy(clone_Stars, 0.5f);
            Destroy(clone_Points, 3.2f);
        }
    }
}
