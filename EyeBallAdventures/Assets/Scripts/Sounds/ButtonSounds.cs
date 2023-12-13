using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource myAudioSource;

    [SerializeField]
    private AudioClip clickSound;

    // Start is called before the first frame update
    public void ClickSound()
    {
        myAudioSource.PlayOneShot(clickSound);
    }
}
