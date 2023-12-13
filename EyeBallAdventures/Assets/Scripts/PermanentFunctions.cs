using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class PermanentFunctions : MonoBehaviour
{
    internal int InitialLivesCount => 5;

    internal static PermanentFunctions instance;
    [SerializeField] internal Vector2 lastCheckPointPosition;
    internal Vector2 startPosition = new Vector2(0, -1f);
    internal int flagCounts = 2;
    internal int remainingLives = 5;
    internal int collectedCoinsPerLvl;
    internal int collectedCoinsTemp;

    internal int destroyedBoxesPerLvl;
    internal int destroyedBoxesTemp;

    internal int dropsCollectedPerLvl;
    internal int dropsCollectedTemp;
    internal int lifePickUpPoints = 0;
    public int GettingDamagedCount { get; set; } = 0;
    //internal int levelCompletedStars;

    //this starts before Start() function
    private void Awake()
    {
        //checking if there is isntance of this object, if not, create one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);

        }
        //if there was already instance of the object, destroy it, to aovid multiple gameobject of this type
        else
        {
            Destroy(this.gameObject);
        }
    }
}
