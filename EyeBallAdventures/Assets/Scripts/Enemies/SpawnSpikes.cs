using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpikes : MonoBehaviour
{
    [SerializeField] private GameObject spikeToSpawn;
    [SerializeField] private bool stopSpawning = false;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    private GameObject clone;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnSpike", spawnTime, spawnDelay);
    }

   private void SpawnSpike()
    {
        clone = Instantiate(spikeToSpawn, this.transform.position, this.transform.rotation);
        if (stopSpawning == true)
        {
            CancelInvoke("SpawnSpike");
        }
        Destroy(clone, 5f);
    }
}
