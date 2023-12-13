using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSceneSounds : MonoBehaviour
{
    private AudioSource myAudioSource;
    [SerializeField]
    private AudioClip finishSound;
    internal bool wasPlayed;
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        wasPlayed = false;
    }

    private void Update()
    {
        Debug.Log(wasPlayed);
        if (wasPlayed == false && this.gameObject.activeSelf.Equals(true))
        {
            myAudioSource.PlayOneShot(finishSound);
            wasPlayed = true;
        }
    }
    private void OnDisable()
    {
        wasPlayed = false;
    }
}
