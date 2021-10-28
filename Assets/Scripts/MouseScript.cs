using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{
    public StructureCard card;
    public Image cardImage;

    private void Start()
    {
        cardImage.sprite = card.cardDisplay;
    }

    public void OnMouseUp()
    {
        card.ChangeBunkerSize();

        Debug.Log($"Current Bunker Size: {PlayerState.BunkerSize}");
    }
}
