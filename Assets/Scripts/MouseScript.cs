using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{
    StructureCard structureCard;
    SabotageCard sabotageCard;
    ScrapyardCard scrapyardCard;
    TricksterCard tricksterCard;

    List<GameObject> field = new List<GameObject>();

    public void OnMouseUp()
    {
        switch (gameObject.tag)
        {
            case "Deck":
                GameState.DrawCards(6 - PlayerState.hand.Count);
                break;
            case "Structure":
                foreach (StructureCard card in GameState.structureCards)
                {
                    if (gameObject.name == card.name)
                    {
                        card.ChangeBunkerSize();
                        break;
                    }
                }

                PlayerState.hand.Remove(gameObject);
                PlayerState.field.Add(gameObject);
                break;
            case "Trickster":
                foreach (TricksterCard card in GameState.tricksterCards)
                {
                    if (gameObject.name == card.name && gameObject.name == "Forced Collapse")
                    {
                        card.ForceCollapse();
                    }
                }
                PlayerState.hand.Remove(gameObject);
                GameState.discard.Add(gameObject);
                
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }
}
