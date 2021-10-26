using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueCardDisplay : MonoBehaviour
{
    public ValueCards card;

    public Image cardDisplay;
    // Start is called before the first frame update
    void Start()
    {
        cardDisplay.sprite = card.cardDesign;
    }
}
