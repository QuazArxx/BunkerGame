using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fiend Card", menuName = "Fiend Card")]
public class FiendCard : ScriptableObject
{
    public new string name;

    public string tag = "Fiend";
    public string civEffectText;
    public string civFlavorText;

    public string fiendEffectText;
    public string fiendFlavorText;

    public int amountInDeck;

    public bool staysOnField;
}
