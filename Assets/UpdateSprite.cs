using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;

    private SpriteRenderer spriteRenderer;
    private GameState gameState;

    private Selectable selectable;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = GameState.BuildDeck();
        gameState = FindObjectOfType<GameState>();

        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = gameState.sprites[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
    }
}
