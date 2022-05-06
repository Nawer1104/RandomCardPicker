using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSelect : MonoBehaviour
{
    [SerializeField] string filename;
    [SerializeField] List<Card> deck = new List<Card>();  
    public float total = 0;

    public List<Card> result = new List<Card>();
    private List<CardUI> cardUIs = new List<CardUI>();

    public Transform parent;
    public GameObject cardprefab;
    public int totalCard;
    public Text remainingRoll;
    public int numberRoll;

    private void Awake()
    {
        deck = FileHandler.ReadListFromJSON<Card>(filename);
        remainingRoll.text = "You have: " + numberRoll + " roll left!";
    }

    void Start()
    {
        for (int i = 0; i < deck.Count; i++)
        {           
            total += deck[i].weight;
        }     
    }

    public void ResultSelect()
    {
        if (numberRoll > 0)
        {
            result.Clear();
            foreach (CardUI card in cardUIs)
            {
                Destroy(card.gameObject);
            }

            cardUIs.Clear();

            for (int i = 0; i < totalCard; i++)
            {

                result.Add(RandomCard());

                CardUI cardUI = Instantiate(cardprefab, parent).GetComponent<CardUI>();

                cardUI.CardUISet(result[i]);

                cardUIs.Add(cardUI);
            }
            numberRoll--;
            remainingRoll.text = "You have: " + numberRoll + " roll left!";
        } else
        {
            remainingRoll.text = "You can not roll anymore!!";
        }
    }
    
    public Card RandomCard()
    {
        float weight = 0;
        int selectNum = 0;

        selectNum = Mathf.RoundToInt(total * Random.Range(0.0f, 1.0f));

        for (int i = 0; i < deck.Count; i++)
        {
            weight += deck[i].weight;
            if (selectNum <= weight)
            {
                Card temp = new Card(deck[i]);
                return temp;
            }
        }
        return null;
    }

}
