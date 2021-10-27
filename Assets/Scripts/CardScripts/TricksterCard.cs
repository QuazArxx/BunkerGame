using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trickster Card", menuName = "Trickster Card")]
public class TricksterCard : ScriptableObject
{
    public new string name;

    public string civEffectText;
    public string civFlavorText;

    public string fiendEffectText;
    public string fiendFlavorText;

    public int amountInDeck;

    public bool staysOnField;
}
