using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite civCardFace;
    public Sprite fiendCardFace;
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
                civCardFace = gameState.civSprites[i];
                fiendCardFace = gameState.fiendSprites[i];
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
            if (PlayerState.isFiend == true)
            {
                spriteRenderer.sprite = fiendCardFace;
            }
            else
            {
                spriteRenderer.sprite = civCardFace;
            }
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
    }
}
