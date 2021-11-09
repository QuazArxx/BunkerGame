using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private static int drawCardCount;
    public Text collapse;
    public Sprite[] civSprites;
    public Sprite[] fiendSprites;
    public GameObject cardPrefab;
    public GameObject deckLocation;

    public static StructureCard[] structureCards;
    public static SabotageCard[] sabotageCards;
    public static ScrapyardCard[] scrapyardCards;
    public static TricksterCard[] tricksterCards;
    public static FiendCard[] fiendCards;

    public static List<GameObject> cardObjects;
    public static List<string> deck;
    public static List<string> cardTypes;
    public static List<GameObject> discard = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PlayerState.BunkerSize = 0;
        PlayerState.isFiend = false;

        PlayerState.hand = new List<GameObject>();

        drawCardCount = 0;

        cardObjects = new List<GameObject>();

        deckLocation = GameObject.Find("Deck");

        structureCards = Resources.LoadAll<StructureCard>("Structure Cards");
        sabotageCards = Resources.LoadAll<SabotageCard>("Sabotage Cards");
        scrapyardCards = Resources.LoadAll<ScrapyardCard>("Scrapyard Cards");
        tricksterCards = Resources.LoadAll<TricksterCard>("Trickster Cards");
        fiendCards = Resources.LoadAll<FiendCard>("Fiend Cards");

        PlayCards();

        if (PlayerState.hand == null)
        {
            Debug.Log($"Current hand size is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float handOffset = -6f;
        foreach (GameObject card in PlayerState.hand)
        {
            if (card.name == "Fiend")
            {
                PlayerState.isFiend = true;
            }

            card.GetComponent<Selectable>().faceUp = true;

            card.transform.position = new Vector3(0f + handOffset, -3f, 0f);
            handOffset += 2.5f;
        }

        float fieldOffset = -6f;
        if (PlayerState.field != null)
        {
            foreach (GameObject card in PlayerState.field)
            {
                card.transform.position = new Vector3(0f + fieldOffset, 0f, 0f);
                fieldOffset += 2.5f;
            }
        }

        float discardOffset = 0.03f;
        if (discard != null)
        {
            foreach (GameObject card in discard)
            {
                card.transform.position = new Vector3(7f, 3f, 0f + discardOffset);
                discardOffset += 0.01f;
            }
        }

        foreach (GameObject card in PlayerState.hand)
        {
            if (card.name == "Fiend")
            {
                PlayerState.hand.Remove(card);
                
                foreach (GameObject fieldCard in PlayerState.field)
                {
                    discard.Add(fieldCard);
                }

                PlayerIsFiend();
                PlayerState.field.Add(card);
                break;
            }
        }
        
        if (PlayerState.BunkerSize > 10)
        {
            StartCoroutine(BunkerCollapse("Your Bunker Collapsed!", 3));
        }

        if (PlayerState.BunkerSize == 10)
        {
            EndGame();
        }
    }

    void ShuffleDeck<T>(List<T> list, List<T> secondList)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);

            n--;

            T temp = list[k];
            T tempTwo = secondList[k];

            list[k] = list[n];
            secondList[k] = secondList[n];

            list[n] = temp;
            secondList[n] = tempTwo;
        }
    }

    void PlayCards()
    {
        deck = BuildDeck();
        cardTypes = GetCardTypes();
        ShuffleDeck(deck, cardTypes);

        BunkerDeal();

        DrawCards(6);
    }

    void BunkerDeal()
    {
        float offset = 0.03f;

        for (int x = 0; x < deck.Count; x++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(deckLocation.transform.position.x, deckLocation.transform.position.y, deckLocation.transform.position.z + offset), Quaternion.identity, deckLocation.transform);

            newCard.name = deck[x];
            newCard.tag = cardTypes[x];

            cardObjects.Add(newCard);

            offset += 0.01f;
        }
    }

    public static List<string> BuildDeck()
    {
        List<string> newDeck = new List<string>();

        // Instantiates all Structure Cards
        foreach (StructureCard card in structureCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newDeck.Add(card.name);
            }
        }

        // Instantiates all Sabotage Cards
        foreach (SabotageCard card in sabotageCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newDeck.Add(card.name);
            }
        }

        // Instantiates all Scrapyard Cards
        foreach (ScrapyardCard card in scrapyardCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newDeck.Add(card.name);
            }
        }

        // Instantiates all Trickster Cards
        foreach (TricksterCard card in tricksterCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newDeck.Add(card.name);
            } 
        }

        // Instantiates all Fiend Cards
        foreach (FiendCard card in fiendCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newDeck.Add(card.name);
            }
        }

        return newDeck;
    }

    public static List<string> GetCardTypes()
    {
        List<string> newCardType = new List<string>();

        // Instantiates all Structure Cards
        foreach (StructureCard card in structureCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newCardType.Add(card.tag);
            }
        }

        // Instantiates all Sabotage Cards
        foreach (SabotageCard card in sabotageCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newCardType.Add(card.tag);
            }
        }

        // Instantiates all Scrapyard Cards
        foreach (ScrapyardCard card in scrapyardCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newCardType.Add(card.tag);
            }
        }

        // Instantiates all Trickster Cards
        foreach (TricksterCard card in tricksterCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newCardType.Add(card.tag);
            } 
        }

        // Instantiates all Fiend Cards
        foreach (FiendCard card in fiendCards)
        {
            for (int x = 0; x < card.amountInDeck; x++)
            {
                newCardType.Add(card.tag);
            }
        }

        return newCardType;
    }

    public static void DrawCards(int amount)
    {
        for (int x = 0; x < amount; x++)
        {
            PlayerState.hand.Add(cardObjects[drawCardCount]);
            drawCardCount++;
        }
    }

    IEnumerator BunkerCollapse(string message, float delay)
    {
        foreach (GameObject card in PlayerState.field)
        {
            discard.Add(card);
        }

        PlayerState.field.Clear();

        PlayerState.BunkerSize = 0;
        collapse.text = message;
        collapse.enabled = true;

        yield return new WaitForSeconds(delay);
        collapse.enabled = false;
    }

    public static void PlayerIsFiend()
    {
        if (PlayerState.field != null)
        {
            PlayerState.field.Clear();
        }

        DrawCards(6 - PlayerState.hand.Count);
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
    }
}
