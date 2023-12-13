using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameSounds : MonoBehaviour
{
    [SerializeField]
    private AudioSource inGameUIAudioSource, congratzSceneAudioSource;

    [SerializeField]
    private AudioClip introGameSound, congratzSceneSound;

    [SerializeField] List<AudioClip> levelsMusic;

    [SerializeField]
    private GameObject inGameUI, mainMenu, congratzScene;

    [SerializeField]
    private Button mainMenuPlayerButton;

    private GameObject player;
    private PlayButtonMusicRestart playButtonRestartIntro;
    private bool wasPlayed, introWasPlayedOnce, congratzWasPlayed;

    private void Start()
    {
        wasPlayed = false;
        introWasPlayedOnce = false;
        congratzWasPlayed = false;

        inGameUIAudioSource.loop = true;
        congratzSceneAudioSource.loop = true;

        //inGameUIAudioSource.clip = level_1_backGroundMusic;
        playButtonRestartIntro = mainMenuPlayerButton.GetComponent<PlayButtonMusicRestart>();
    }

    private void Update()
    {
        if (playButtonRestartIntro.restartMusicClicked == true && introWasPlayedOnce == false && inGameUI.activeSelf.Equals(true))
        {              
            playButtonRestartIntro.restartMusicClicked = false;
        }

        if (wasPlayed == false && inGameUI.activeSelf.Equals(true))
        {            
            StartMusic();
        }

        else if(wasPlayed == true && inGameUI.activeSelf.Equals(false))
        {
            wasPlayed = false;
            PauseMusic();
        }

        if (congratzWasPlayed == false && congratzScene.activeSelf.Equals(true))
        {
            if(SceneManager.GetActiveScene().buildIndex == 12)
            {
                if (congratzSceneSound != null && congratzSceneAudioSource != null)
                {
                    congratzSceneAudioSource.clip = congratzSceneSound;
                    congratzSceneAudioSource.volume = 0.5f;
                    congratzSceneAudioSource.Play();
                    congratzWasPlayed = true;
                }
            }
        }

        if (mainMenu.activeSelf.Equals(true) && introWasPlayedOnce == true)
        {
            introWasPlayedOnce = false;
        }

        if (inGameUI.activeSelf.Equals(true))
        {
            
            if (introWasPlayedOnce == false && GameObject.FindGameObjectWithTag("Player") != null)
            {
                inGameUIAudioSource.PlayOneShot(introGameSound);
                introWasPlayedOnce = true;
            }

            else if(GameObject.FindGameObjectWithTag("Player") == null && introWasPlayedOnce == true)
            {
                introWasPlayedOnce = false;
            }
        }
        else if(inGameUI.activeSelf.Equals(false))
        {
            introWasPlayedOnce = false;
        }
    }

    private void StartMusic()
    {
        for (int currentSongIndex = 0; currentSongIndex < levelsMusic.Count; currentSongIndex++)
        {
            if (SceneManager.GetActiveScene().buildIndex == currentSongIndex)
            {
                AudioClip currentSong = levelsMusic[currentSongIndex];
                

                if (currentSong != null && inGameUIAudioSource != null)
                {
                    inGameUIAudioSource.clip = currentSong;
                    inGameUIAudioSource.volume = 0.5f;

                    inGameUIAudioSource.Play();
                    wasPlayed = true;
                }
            }           
        }

       
    }

    public void ResetCongratzSceneMusic()
    {
        congratzWasPlayed = false;
    }

    private void PauseMusic()
    {
        if (inGameUIAudioSource != null)
        {
            inGameUIAudioSource.Stop();
            
        }
        
    }
}
