using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveHandler : MonoBehaviour, IPointerClickHandler
{
    internal bool saveButtonClicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        saveButtonClicked = true;
    }
}
