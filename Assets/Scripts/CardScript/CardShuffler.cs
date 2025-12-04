using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardShuffler : MonoBehaviour
{
    public float refreshCD;//最初刷新冷却
    public float currentCD;//当前CD

    public bool isInRefresh = false;

    public GameObject cardPrefab;//卡牌预制体
    public Transform HandArea;//刷新位置
    public CardInventery Inventery;//抽取的卡牌库


    private void Start()
    {
        DrawCard();
        DrawCard();
        DrawCard();
    }


    private void Update()
    {
        ResetRefreshCD();
    }


    public void ResetRefreshCD()
    {
        if (HandArea.childCount < 3)
        {
            isInRefresh = true;
            currentCD = refreshCD;
            currentCD -= Time.deltaTime;
            if (currentCD == 0f)
            {
                DrawCard();
                isInRefresh = false;               
            }
        }
    }

    public void DrawCard()
    {
        int cardID = Random.Range(0, Inventery.cardList.Count);
        CardMessage data = Inventery.cardList[cardID];
        GameObject newCard = Instantiate(cardPrefab, HandArea);
        newCard.GetComponent<CardCreat>().Init(data);
    }       
}
