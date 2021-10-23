using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class MouseHoverColors : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI text;

    void Awake () 
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        text.color = new Color32(151, 41, 54, 255);

        text.fontMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 1.0f);
        text.UpdateMeshPadding();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.color = new Color32(50, 50, 50, 255);

        text.fontMaterial.SetFloat(ShaderUtilities.ID_GlowPower, 0.0f);
        text.UpdateMeshPadding();
    }
}
