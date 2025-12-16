using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    [Header("设置")]
    public Camera mainCamera;//拖入主摄像机
    public LayerMask monsterLayer;

    private CardCreat currentSelectedCard;
    private bool isTargeting = false;//瞄准状态，开启时可选攻击的怪物

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    { 
        if(isTargeting && Input.GetMouseButtonDown(0))
        {
            if(currentSelectedCard.CardClass == 0)
            {
                DetectMonsterClick();
            }
        }

        if(isTargeting && Input.GetMouseButtonDown(1))
        {
            CancelSelection();
        }
    }

    public void SelectCard(CardCreat mySelectCard)
    {
        
        currentSelectedCard = mySelectCard;
        isTargeting = true;
        Debug.Log("已选中攻击卡牌");
    }

    private void CancelSelection()//取消对当前卡牌的选择
    {
        currentSelectedCard = null;
        isTargeting = false;

    }

    private void DetectMonsterClick()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, monsterLayer);

        if (hit.collider != null)
        {
            MonsterCreat target = hit.collider.GetComponent<MonsterCreat>();
            if (target != null)
            {
                AttackMonster(target);
                Debug.Log("攻击怪物");
            }
            else
            {
                //没选中怪物则重置选择状态
                CancelSelection();
                Debug.Log("没点中怪物");
            }
        }


        /*废弃方案
        if (Physics.Raycast(ray, out hit,100f ,monsterLayer))
        {
            Debug.Log(hit.collider.name);
            MonsterCreat target = hit.collider.GetComponent<MonsterCreat>();
            if(target != null)
            {
                AttackMonster(target);
                Debug.Log("攻击怪物");
            }
        }
        else
        {
            //没选中怪物则重置选择状态
            CancelSelection();
            Debug.Log("没点中怪物");
        }*/
    }

    /*攻击逻辑*/
    private void AttackMonster(MonsterCreat target)
    {
        if(currentSelectedCard == null)
        {
            return;
        }
        //卡牌效果写这里
        float dmg = currentSelectedCard.Card.Damage;

        //参数传入MonsterCreat类
        target.TakeDamage(dmg);

        //检测卡牌携带的buff并触发
        foreach (var effect in currentSelectedCard.Card.BuffMessages)
        {
            BuffMessage newBuff = Instantiate(effect);
            newBuff.Init();
            target.monsterBuff.Add(newBuff);
        }

        //此处写销毁卡牌
        Destroy(currentSelectedCard.gameObject);

        //此处写重置选择状态
        CancelSelection();

        Debug.Log("已攻击怪物");
    }
}
