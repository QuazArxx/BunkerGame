using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseHoverColors : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text text;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = new Color32(151, 41, 54, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = new Color32(50, 50, 50, 255);
    }
}
