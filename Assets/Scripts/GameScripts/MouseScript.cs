using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{
    static GameObject CardText;
    Text cardNameText;
    Text cardDescriptionText;
    StructureCard structureCard;
    SabotageCard sabotageCard;
    ScrapyardCard scrapyardCard;
    TricksterCard tricksterCard;

    List<GameObject> field = new List<GameObject>();

    private void Awake()
    {
        CardText = GameObject.Find("Main Camera");
        cardNameText = CardText.GetComponent<Text>();
        cardDescriptionText = CardText.GetComponent<Text>();
    }

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

    public void OnMouseOver()
    {
        switch (gameObject.tag)
        {
            case "Structure":
                foreach (StructureCard card in GameState.structureCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = card.name;
                        cardDescriptionText.text = card.civEffectText;

                        
                    }
                }

                Debug.Log($"Hovering over a Structure Card");
                break;
            case "Trickster":
                foreach (TricksterCard card in GameState.tricksterCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = "Some Card";
                        cardDescriptionText.text = card.civEffectText;
                        Debug.Log($"Hovering over {card.name}");
                    }
                }
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }

    public void OnMouseExit()
    {
        switch (gameObject.tag)
        {
            case "Structure":
                foreach (StructureCard card in GameState.structureCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = "";
                        cardDescriptionText.text = "";
                    }
                }
                break;
            case "Trickster":
                foreach (TricksterCard card in GameState.tricksterCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = "";
                        cardDescriptionText.text = "";
                    }
                }
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }
}

