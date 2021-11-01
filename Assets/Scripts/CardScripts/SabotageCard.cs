using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sabotage Card", menuName = "Sabotage Card")]
public class SabotageCard : ScriptableObject
{
    public new string name;

    public string tag = "Sabotage";
    public string civEffectText;
    public string civFlavorText;

    public string fiendEffectText;
    public string fiendFlavorText;

    public int value;
    public int amountInDeck;

    public bool staysOnField;
}
