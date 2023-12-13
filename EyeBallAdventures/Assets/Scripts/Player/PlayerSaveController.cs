using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;

internal class PlayerSaveController : MonoBehaviour
{
    [SerializeField] private List<GameObject> saveFlags;
    private bool pressedSave = false;
    private CashCollector cashCollector;
    internal TextMeshProUGUI flagsNumberText;
    private bool flagCounterIsActive = false;
    private SaveHandler saveButton;
    private bool solidGround = false;
    private bool isGrounded = false;
    private PlayerMovement playerMovement;
    private bool flagCountUIFound;


    // Start is called before the first frame update
    private void Start()
    {
        flagCountUIFound = false;
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
        if (PermanentFunctions.instance.remainingLives > 0 && PermanentFunctions.instance.flagCounts == 0)
        {
            PermanentFunctions.instance.flagCounts = 0;
        }

        //if (GameObject.FindGameObjectWithTag("FlagCounterText") != null)
        //{
        //    this.flagsNumberText = GameObject.FindGameObjectWithTag("FlagCounterText").GetComponent<TextMeshProUGUI>();
        //    flagsNumberText.text = PermanentFunctions.instance.flagCounts.ToString();
        //    flagCounterIsActive = true;
        //}

        //if (GameObject.FindGameObjectWithTag("SaveButton") != null)
        //{
        //    saveButton = GameObject.FindGameObjectWithTag("SaveButton").GetComponent<SaveHandler>();
        //}
        cashCollector = GetComponent<CashCollector>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (flagCountUIFound == false && GameObject.FindGameObjectWithTag("FlagCounterText") != null)
        {
            this.flagsNumberText = GameObject.FindGameObjectWithTag("FlagCounterText").GetComponent<TextMeshProUGUI>();
            flagsNumberText.text = PermanentFunctions.instance.flagCounts.ToString();
            flagCounterIsActive = true;

            saveButton = GameObject.FindGameObjectWithTag("SaveButton").GetComponent<SaveHandler>();

            flagCountUIFound = true;
        }

        if (saveButton != null)
        {
            if (Input.GetKeyDown(KeyCode.P) || saveButton.saveButtonClicked == true)
            {
                if (solidGround == true)
                {
                    PutTheFlag();
                    saveButton.saveButtonClicked = false;
                }  
                else
                {
                    saveButton.saveButtonClicked = false;
                }
            }
        }
    }

    public void PutTheFlag()
    {
        pressedSave = true;
        if (pressedSave && saveFlags.Any() && PermanentFunctions.instance.flagCounts > 0 && flagCounterIsActive)
        {
            if (cashCollector.coins >= 10)
            {

                PermanentFunctions.instance.collectedCoinsPerLvl += PermanentFunctions.instance.collectedCoinsTemp;
                PermanentFunctions.instance.collectedCoinsTemp = 0;

                PermanentFunctions.instance.destroyedBoxesPerLvl += PermanentFunctions.instance.destroyedBoxesTemp;
                PermanentFunctions.instance.destroyedBoxesTemp = 0;

                PermanentFunctions.instance.dropsCollectedPerLvl += PermanentFunctions.instance.dropsCollectedTemp;
                PermanentFunctions.instance.dropsCollectedTemp = 0;

                cashCollector.coins -= 10;
                string coinsNumber = cashCollector.coins.ToString();
                cashCollector.coinsText.text = coinsNumber;

                Instantiate(saveFlags[saveFlags.Count - 1], this.transform.position, transform.rotation);

                PermanentFunctions.instance.flagCounts--;
                flagsNumberText.text = PermanentFunctions.instance.flagCounts.ToString();

                saveFlags.RemoveAt(saveFlags.Count - 1);
                pressedSave = false;                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        if (otherObject.CompareTag("StaticPlatform"))
        {
            solidGround = true;
        }        
    }

    private void OnTriggerStay2D(Collider2D otherObject)
    {
        if (solidGround == false && playerMovement.CheckIfIsGrounded() == true && otherObject.CompareTag("StaticPlatform"))
        {
            isGrounded = true;
            solidGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (solidGround == true)
        {
            solidGround = false;
            isGrounded = false;
        }
    }
}
