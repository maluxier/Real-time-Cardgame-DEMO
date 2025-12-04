using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardCreat : MonoBehaviour, IPointerClickHandler
{
    [Header("UI组件数据")]
    public Text CardName;
    public Image CardImage;
    public Text CardInfo;


    
    private int CardClass;

    public CardMessage Card;

    public CardInventery myCardInventery;

    public void Init(CardMessage data)//初始化方法，由发牌器在生产卡牌时调用
    {
        this.Card = data;

        // 刷新 UI
        CardName.text = data.CardName;
        CardImage.sprite = data.CardImage;
        CardInfo.text = data.CardInfo;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        BattleManager.instance.SelectCard(this);
    }
}
