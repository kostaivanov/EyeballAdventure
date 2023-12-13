using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TogglesColorController : MonoBehaviour
{
    private Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(OnToggleValueChanged);
    }

    private void OnToggleValueChanged(bool isOn)
    {
        ColorBlock colorBlack = toggle.colors;
        if (isOn)
        {
            colorBlack.normalColor = new Color(0.7f, 0.7f, 0.7f);
            colorBlack.highlightedColor = new Color(0.6f, 0.6f, 0.6f);
            colorBlack.pressedColor = new Color(0.8f, 0.8f, 0.8f);
        }
        else
        {
            colorBlack.normalColor = Color.white;
            colorBlack.highlightedColor = Color.white;
        }
        toggle.colors = colorBlack;
        EventSystem.current.SetSelectedGameObject(null);
    }
}
