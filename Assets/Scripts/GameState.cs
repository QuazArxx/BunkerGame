using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    public Text collapse;
    public Sprite[] sprites;
    public GameObject cardPrefab;
    public GameObject deckLocation;

    private static StructureCard[] structureCards;
    private static SabotageCard[] sabotageCards;
    private static ScrapyardCard[] scrapyardCards;
    private static TricksterCard[] tricksterCards;
    private static FiendCard[] fiendCards;

    public static List<string> deck;
    public static List<string> cardTypes;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState.BunkerSize = 0;
        PlayerState.isFiend = false;

        deckLocation = GameObject.FindWithTag("Deck");

        structureCards = Resources.LoadAll<StructureCard>("Structure Cards");
        sabotageCards = Resources.LoadAll<SabotageCard>("Sabotage Cards");
        scrapyardCards = Resources.LoadAll<ScrapyardCard>("Scrapyard Cards");
        tricksterCards = Resources.LoadAll<TricksterCard>("Trickster Cards");
        fiendCards = Resources.LoadAll<FiendCard>("Fiend Cards");

        PlayCards();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (string card in PlayerState.hand)
        {
            if (card == "Fiend")
            {
                PlayerState.isFiend = true;
                Debug.Log($"Player is the fiend: {PlayerState.isFiend}");
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

        PlayerState.hand = DrawCards(5);
    }

    void BunkerDeal()
    {
        for (int x = 0; x < deck.Count; x++)
        {
            GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);

            newCard.name = deck[x];
            newCard.tag = cardTypes[x];
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

    public static List<string> DrawCards (int amount)
    {
        List<string> newHand = new List<string>();

        for (int x = 0; x < amount; x++)
        {
            newHand.Add(deck[x]);
        }
        
        return newHand;
    }

    IEnumerator BunkerCollapse(string message, float delay)
    {
        PlayerState.BunkerSize = 0;
        collapse.text = message;
        collapse.enabled = true;

        yield return new WaitForSeconds(delay);
        collapse.enabled = false;
    }

    void EndGame()
    {
        SceneManager.LoadScene("EndGame", LoadSceneMode.Single);
    }
}
