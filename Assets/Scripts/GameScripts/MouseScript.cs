using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{
    GameState gameState;
    Text cardNameText;
    Text cardDescriptionText;

    Color alpha;
    float alphaAmount = 0.75f;

    List<GameObject> field = new List<GameObject>();

    private void Awake()
    {
        gameState = FindObjectOfType<GameState>();
        cardNameText = gameState.cardNameText;
        cardDescriptionText = gameState.cardDescriptionText;

        alpha = gameState.panel.color;
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

                        if (PlayerState.isFiend == true)
                        {
                            cardDescriptionText.text = card.fiendEffectText;
                        }
                        else
                        {
                            cardDescriptionText.text = card.civEffectText;
                        }

                        gameState.cardNameText.text = cardNameText.text;
                        gameState.cardDescriptionText.text = cardDescriptionText.text;

                        alpha.a = alphaAmount;
                        gameState.panel.color = alpha;
                    }
                }
                break;
            case "Trickster":
                foreach (TricksterCard card in GameState.tricksterCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = card.name;

                        if (PlayerState.isFiend == true)
                        {
                            cardDescriptionText.text = card.fiendEffectText;
                        }
                        else
                        {
                            cardDescriptionText.text = card.civEffectText;
                        }

                        gameState.cardNameText.text = cardNameText.text;
                        gameState.cardDescriptionText.text = cardDescriptionText.text;

                        alpha.a = alphaAmount;
                        gameState.panel.color = alpha;
                    }
                }
                break;
            case "Sabotage":
                foreach (SabotageCard card in GameState.sabotageCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = card.name;

                        if (PlayerState.isFiend == true)
                        {
                            cardDescriptionText.text = card.fiendEffectText;
                        }
                        else
                        {
                            cardDescriptionText.text = card.civEffectText;
                        }
                        
                        gameState.cardNameText.text = cardNameText.text;
                        gameState.cardDescriptionText.text = cardDescriptionText.text;

                        alpha.a = alphaAmount;
                        gameState.panel.color = alpha;
                    }
                }
                break;
            case "Scrapyard":
                foreach (ScrapyardCard card in GameState.scrapyardCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = card.name;

                        if (PlayerState.isFiend == true)
                        {
                            cardDescriptionText.text = card.fiendEffectText;
                        }
                        else
                        {
                            cardDescriptionText.text = card.civEffectText;
                        }

                        gameState.cardNameText.text = cardNameText.text;
                        gameState.cardDescriptionText.text = cardDescriptionText.text;

                        alpha.a = alphaAmount;
                        gameState.panel.color = alpha;
                    }
                }
                break;
            case "Deck":
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

                        alpha.a = 0;
                        gameState.panel.color = alpha;
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

                        alpha.a = 0;
                        gameState.panel.color = alpha;
                    }
                }
                break;
            case "Sabotage":
                foreach (SabotageCard card in GameState.sabotageCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = "";
                        cardDescriptionText.text = "";

                        alpha.a = 0;
                        gameState.panel.color = alpha;
                    }
                }
                break;
            case "Scrapyard":
                foreach (ScrapyardCard card in GameState.scrapyardCards)
                {
                    if (gameObject.name == card.name)
                    {
                        cardNameText.text = "";
                        cardDescriptionText.text = "";

                        alpha.a = 0;
                        gameState.panel.color = alpha;
                    }
                }
                break;
            case "Deck":
                break;
            default:
                Debug.Log("Something went wrong!");
                break;
        }
    }
}

