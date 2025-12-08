using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardShuffler : MonoBehaviour
{
    //此处的CD设置做测试使用，后面是需要接收装备数据来赋值的
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
        if(HandArea.childCount < 3)
        {
            ResetRefreshCD();
        }       
    }


    public void ResetRefreshCD()
    {
        Debug.Log("进入CD");
        if (!isInRefresh)
        {
            isInRefresh = true;
            currentCD = refreshCD;
        }           

        currentCD -= Time.deltaTime;

        if (currentCD <= 0f)
        {
            DrawCard();
            isInRefresh = false;
            currentCD = 0f;
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
