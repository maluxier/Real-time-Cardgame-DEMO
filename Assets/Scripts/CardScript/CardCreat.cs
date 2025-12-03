using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardCreat : MonoBehaviour, IPointerClickHandler
{
    public Text CardName;
    public Image CardImage;
    public Text CardInfo;

    private int CardClass;

    public CardMessage Card;

    public CardInventery myCardInventery;

    private void Start()
    {
        int maxCardListID = myCardInventery.cardList.Count;
        int randomID = Random.Range(0, maxCardListID);
        Card = myCardInventery.cardList[randomID];

        CardName.text = Card.CardName.ToString();
        CardImage.sprite = Card.CardImage;
        CardInfo.text = Card.CardInfo.ToString();
        CardClass = Card.CardClass;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.instance.SelectCard(this);
    }
}
