using System;
using System.IO;
using UnityEngine;

public class CardEffects : MonoBehaviour
{
    public TextAsset jsonFile;

    Cards cardsInJson;

    Card card;

    void Start()
    {
        cardsInJson = JsonUtility.FromJson<Cards>(jsonFile.text);

        foreach (Card card in cardsInJson.cards)
        {
            if (card.values != null)
            {
                Debug.Log("Card name: " + card.name + " with " + card.values[0].civilian + " in the deck.");
            }
        }
    }

    /*public void AddOrRemoveFromBunker(Card card)
    {
        if (PlayerState.BunkerSize > 0)
        {
            PlayerState.BunkerSize += 
        }
    }*/
}
