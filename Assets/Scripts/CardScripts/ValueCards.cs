using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "ValueCard")]
public class ValueCards : ScriptableObject
{
    public new string name;
    public string civFlavorText;
    public string fiendFlavorText;
    public string civEffectText;
    public string fiendEffectText;
    public string type;

    public Sprite cardDesign;

    public int civValue;
    public int fiendValue;
    public int amountInDeck;

    public bool staysOnField;
}