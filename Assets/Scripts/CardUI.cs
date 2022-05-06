using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour, IPointerDownHandler
{
   
    public Image chr;
    public Text cardName;
    public Text cardDescription;
    public Text cardValuable;
    Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void CardUISet(Card card)
    {
        WebRequest.GetTexture(card.cardImageUrl, (string error) =>
        {
            Debug.Log("Error: " + error);
        }, (Texture2D texture2D) =>
        {
            Sprite sprite = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), new Vector2(0, 0));
            chr.sprite = sprite;           
        });        
        cardName.text = card.cardName;
        cardDescription.text = card.cardDescription;
        cardValuable.text = card.cardValuable;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        animator.SetTrigger("Flip");
    }
}
