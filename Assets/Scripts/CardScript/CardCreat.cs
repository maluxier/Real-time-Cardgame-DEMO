using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardCreat : MonoBehaviour
{
    public Text CardName;
    public Image CardImage;
    public Text CardInfo;

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
    }

}
