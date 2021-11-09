using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trickster Card", menuName = "Trickster Card")]
public class TricksterCard : ScriptableObject
{
    public new string name;

    public string tag = "Trickster";
    public string civEffectText;
    public string civFlavorText;

    public string fiendEffectText;
    public string fiendFlavorText;

    public int amountInDeck;

    public bool staysOnField;

    public void ForceCollapse()
    {
        PlayerState.BunkerSize = 0;

        foreach (GameObject card in PlayerState.field)
        {
            GameState.discard.Add(card);
        }

        PlayerState.field.Clear();
    }
}
