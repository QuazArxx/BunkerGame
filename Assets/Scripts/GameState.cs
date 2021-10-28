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

    private StructureCard[] structureCards;

    // Start is called before the first frame update
    void Start()
    {
        PlayerState.BunkerSize = 0;

        PlayerState.isFiend = false;

        structureCards = Resources.LoadAll<StructureCard>("Structure Cards");
        for (int x = 0; x < structureCards.Length; x++)
        {
            GameObject newStructureCard = Instantiate(cardPrefab, transform.position, Quaternion.identity);
            newStructureCard.name = structureCards[x].name;
            Debug.Log(structureCards[x].name);
        }
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
