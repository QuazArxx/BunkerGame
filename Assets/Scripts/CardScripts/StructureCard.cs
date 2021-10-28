using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Structure", menuName = "Structure Card")]
public class StructureCard : ScriptableObject
{
    public new string name;

    public string civEffectText;
    public string civFlavorText;
    public bool civStaysOnField;

    public string fiendEffectText;
    public string fiendFlavorText;
    public bool fiendStaysOnField;

    public Sprite cardDisplay;

    public int value;
    public int amountInDeck;

    public void ChangeBunkerSize()
    {
        if (PlayerState.isFiend == true)
        {
            if (PlayerState.BunkerSize >= value)
            {
                PlayerState.BunkerSize -= value;
            }
        }
        else
        {
            PlayerState.BunkerSize += value;
        }

        Debug.Log($"New Bunker Size: {PlayerState.BunkerSize}");
    }
}