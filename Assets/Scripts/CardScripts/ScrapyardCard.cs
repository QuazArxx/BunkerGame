using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scrapyard Card", menuName = "Scrapyard Card")]
public class ScrapyardCard : ScriptableObject
{
    public new string name;

    public string tag = "Scrapyard";
    public string civEffectText;
    public string civFlavorText;

    public string fiendEffectText;
    public string fiendFlavorText;

    public int value;
    public int amountInDeck;

    public bool staysOnField;

    /*public void GrabFromScrapyard()
    {
        if (PlayerState.isFiend == false)
        {

        }
    }*/
}
