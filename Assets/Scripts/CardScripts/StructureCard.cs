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

    public int value;
    public int amountInDeck;
}