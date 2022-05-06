using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card 
{
    public string cardId;
    public string cardName;
    public string cardImageUrl;
    public string cardDescription;
    public string cardValuable;
    public float weight;

    public Card(Card card)
    {
        this.cardId = card.cardId;
        this.cardName = card.cardName;
        this.cardImageUrl = card.cardImageUrl;
        this.cardDescription = card.cardDescription;
        this.cardValuable = card.cardValuable;
        this.weight = card.weight;
    }
}
