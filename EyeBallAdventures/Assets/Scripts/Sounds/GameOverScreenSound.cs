using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreenSound : MonoBehaviour
{
    private AudioSource myAudioSource;
    [SerializeField]
    private AudioClip gameOverSound;
    internal bool wasPlayed;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        wasPlayed = false;
    }

    private void Update()
    {
        if (wasPlayed == false && this.gameObject.activeSelf.Equals(true))
        {
            myAudioSource.PlayOneShot(gameOverSound);
            wasPlayed = true;
        }
    }
}
