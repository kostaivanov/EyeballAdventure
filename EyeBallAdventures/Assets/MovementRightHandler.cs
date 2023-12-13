using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MovementRightHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    internal bool moveButtonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.activeSelf == true)
        {
            moveButtonPressed = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.gameObject.activeSelf == true)
        {
            moveButtonPressed = false;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (this.gameObject.activeSelf == true)
        {
            moveButtonPressed = false;
        }
    }
}
