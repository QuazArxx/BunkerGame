using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseScript : MonoBehaviour
{
    public void OnMouseUp()
    {
        if (gameObject.tag == "Deck")
        {
            GameState.DrawCards(1);
        }

        Debug.Log($"Cards in hand: {PlayerState.hand.Count}");
    }
}
