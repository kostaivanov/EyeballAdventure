using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MusicController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] internal List<Sprite> soundIcons;
    private Button soundButton;

    private void Start()
    {
        soundButton  = GetComponent<Button>();
        //if (AudioListener.pause == true)
        //{
        //    soundButton.image.sprite = soundIcons[1];
        //}

        //else
        //{
        //    soundButton.image.sprite = soundIcons[0];
        //}

        if (AudioListener.volume == 0)
        {
            soundButton.image.sprite = soundIcons[1];
        }

        else
        {
            soundButton.image.sprite = soundIcons[0];
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //AudioListener.pause = !AudioListener.pause;
        if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;
        }

        //if (AudioListener.pause == true)
        //{
        //    soundButton.image.sprite = soundIcons[1];
        //}

        //else
        //{
        //    soundButton.image.sprite = soundIcons[0];
        //}

        if (AudioListener.volume == 0)
        {
            soundButton.image.sprite = soundIcons[1];
        }

        else
        {
            soundButton.image.sprite = soundIcons[0];
        }

    }
}
