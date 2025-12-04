using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardShuffler : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform attackHandArea;
    public Transform defenseHandArea;
    public Transform buffHandArea;
    public CardInventery Inventery;

    private void Start()
    {
        DrawCard();
        DrawCard();
        DrawCard();
    }

    public  void DrawCard()
    {
        int cardID = Random.Range(0, Inventery.cardList.Count);
        CardMessage data = Inventery.cardList[cardID];

        switch (data.CardClass)
        {
            case 0:
                {
                    GameObject newCard = Instantiate(cardPrefab, attackHandArea);
                    newCard.GetComponent<CardCreat>().Init(data);
                    break;
                }
                

            case 1:
                {
                    GameObject newCard = Instantiate(cardPrefab, defenseHandArea);
                    newCard.GetComponent<CardCreat>().Init(data);
                    break;
                }


            case 2:
                {
                    GameObject newCard = Instantiate(cardPrefab, buffHandArea);
                    newCard.GetComponent<CardCreat>().Init(data);
                    break;
                }
        }
                   
    }
}
