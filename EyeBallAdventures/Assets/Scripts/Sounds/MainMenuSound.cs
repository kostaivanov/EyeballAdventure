using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource mainMenuAudioSource;

    [SerializeField]
    private AudioClip mainMenuMusic;

    [SerializeField]
    private GameObject mainMenu;

    [SerializeField]
    private Button pauseMenuVolume, mainMenuVolume;

    private MusicController menuVolumeMusicController, pauseVolumeMusicController;

    private bool musicWasPlayed;
    // Start is called before the first frame update
    void Start()
    {
        musicWasPlayed = false;
        mainMenuAudioSource.loop = true;

        pauseVolumeMusicController = pauseMenuVolume.GetComponent<MusicController>();
        menuVolumeMusicController = mainMenuVolume.GetComponent<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainMenu.activeSelf.Equals(true))
        {
            CheckVolumeButton_Icon();

            if (musicWasPlayed == false)
            {
                StartMusic();
            }
        }
        else if (mainMenu.activeSelf.Equals(false) && musicWasPlayed == true)
        {
            StopMusic();
        }
    }

    private void CheckVolumeButton_Icon()
    {
        if (AudioListener.volume == 0)
        {
            pauseMenuVolume.image.sprite = pauseVolumeMusicController.soundIcons[1];
            mainMenuVolume.image.sprite = menuVolumeMusicController.soundIcons[1];
        }

        else
        {
            pauseMenuVolume.image.sprite = pauseVolumeMusicController.soundIcons[0];
            mainMenuVolume.image.sprite = menuVolumeMusicController.soundIcons[0];
        }
    }

    private void StartMusic()
    {
        if (mainMenuMusic != null && mainMenuAudioSource != null)
        {
            mainMenuAudioSource.volume = 1.0f;
            mainMenuAudioSource.clip = mainMenuMusic;
            mainMenuAudioSource.Play();
            musicWasPlayed = true;
        }
    }

    private void StopMusic()
    {
        if (mainMenuAudioSource != null)
        {
            mainMenuAudioSource.Stop();
            musicWasPlayed = false;
        }

    }
}
