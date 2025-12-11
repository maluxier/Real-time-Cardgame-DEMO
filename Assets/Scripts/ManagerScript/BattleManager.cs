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
            DetectMonsterClick();
            
        }

        if(isTargeting && Input.GetMouseButtonDown(1))
        {
            CancelSelection();
        }
    }

    public void SelectCard(CardCreat mySelectCard)
    {
        if(currentSelectedCard == mySelectCard)
        {
            CancelSelection();
            return;
        }

        currentSelectedCard = mySelectCard;
        isTargeting = true;
        Debug.Log("已选中卡牌");
    }

    private void CancelSelection()//取消对当前卡牌的选择
    {
        currentSelectedCard = null;
        isTargeting = false;

    }

    private void DetectMonsterClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);//从摄像机发射射线检测当前点击的是不是怪
        RaycastHit hit;//检测射线击中的物体，设置为hit变量

        if(Physics.Raycast(ray, out hit,100f ,monsterLayer))
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
        }
    }

    private void AttackMonster(MonsterCreat target)
    {
        if(currentSelectedCard == null)
        {
            return;
        }

        //卡牌效果写这里
        int dmg = currentSelectedCard.Card.Damage;

        target.TakeDamage(dmg);//参数传入Monster类

        //此处写销毁卡牌
        Destroy(currentSelectedCard.gameObject);

        //此处写重置选择状态
        CancelSelection();

        Debug.Log("已攻击怪物");
    }
}
