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

    private static StructureCard[] structureCards;
    private static SabotageCard[] sabotageCards;
    private static ScrapyardCard[] scrapyardCards;
    private static TricksterCard[] tricksterCards;
    private static FiendCard[] fiendCards;

    public static List<string> deck;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState.BunkerSize = 0;
        PlayerState.isFiend = false;

        structureCards = Resources.LoadAll<StructureCard>("Structure Cards");
        sabotageCards = Resources.LoadAll<SabotageCard>("Sabotage Cards");
        scrapyardCards = Resources.LoadAll<ScrapyardCard>("Scrapyard Cards");
        tricksterCards = Resources.LoadAll<TricksterCard>("Trickster Cards");
        fiendCards = Resources.LoadAll<FiendCard>("Fiend Cards");

        PlayCards();

        DrawCards(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerState.BunkerSize > 10)
        {
            StartCoroutine(BunkerCollapse("Your Bunker Collapsed!", 3));
        }

        if (PlayerState.BunkerSize == 10)
        {
            EndGame();
        }
    }

    void ShuffleDeck<T>(List<T> list)
    {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            int k = random.Next(n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void PlayCards()
    {
        deck = BuildDeck();
        ShuffleDeck(deck);

        BunkerDeal();
    }

    void BunkerDeal()
    {
        foreach(string card in deck)
        {
            GameObject newCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);

            newCard.name = card;
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

    public void DrawCards (int amount)
    {
        for (int x = 0; x < amount; x++)
        {
            PlayerState.hand.Add(deck[x]);
        }
        Debug.Log(PlayerState.hand.Count);
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
