using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Cards
{
    public Card[] cards;
}

[Serializable]
public class Card
{
    public string id;
    public string type;
    public string name;

    public Values[] values;

    public int amountInDeck;
}

[Serializable]
public class Values
{
    public int civilian;
    public int fiend;
}

[Serializable]
public class EffectTexts
{
    public int civilian;
    public int fiend;
}

[Serializable]
public class FlavorTexts
{
    public int civilian;
    public int fiend;
}

[Serializable]
public class StaysOnField
{
    public bool civilian;
    public bool fiend;
}
