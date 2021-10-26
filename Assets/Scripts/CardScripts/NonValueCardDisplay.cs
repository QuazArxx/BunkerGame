using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NonValueCardDisplay : MonoBehaviour
{
    NonValueCards card;

    public Image cardImage;

    // Start is called before the first frame update
    void Start()
    {
        cardImage.sprite = card.cardDesign;
    }
}
