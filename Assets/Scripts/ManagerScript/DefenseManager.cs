using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MonoBehaviour
{
    public static DefenseManager instance;

    public Camera mainCamera;
    public LayerMask playerLayer;


    private CardCreat currentSelectedCard;
    public bool isTargeting = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {       
        if (isTargeting && Input.GetMouseButtonDown(0))
        {
            if (currentSelectedCard.CardClass == 1)
            {
                Debug.Log("检测到左键");
                DetectPlayerClick();
            }
        }

        if (isTargeting && Input.GetMouseButtonDown(1))
        {
            CancelSelection();
        }
    }

    public void SelectDefenseCard(CardCreat mySelectCard)
    {

        currentSelectedCard = mySelectCard;
        isTargeting = true;
        Debug.Log("已选中防御卡牌");
    }

    private void CancelSelection()//取消对当前卡牌的选择
    {
        currentSelectedCard = null;
        isTargeting = false;

    }

    private void DetectPlayerClick()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f, playerLayer);
        
        if(hit.collider != null)
        {
            Player target = hit.collider.GetComponent<Player>();

            if (target != null)
            {
                Defense(target);
                Debug.Log("防御");
            }
            else
            {
                //没选中怪物则重置选择状态
                CancelSelection();
                Debug.Log("没点中玩家");
            }
        }

        /*废弃方案
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);//从摄像机发射射线检测当前点击的是不是玩家
        RaycastHit hit;//检测射线击中的物体，设置为hit变量
        
        if (Physics.Raycast(ray, out hit, 100f, playerLayer))
        {
            Debug.Log(hit.collider.name);
            Player target = hit.collider.GetComponent<Player>();
            if (target != null)
            {
                Defense(target);
                Debug.Log("防御");
            }
        }
        else
        {
            //没选中怪物则重置选择状态
            CancelSelection();
            Debug.Log("没点中玩家");
        }*/
    }

    public void Defense(Player target)
    {
        if (currentSelectedCard == null)
        {
            return;
        }
        
        float dp = currentSelectedCard.Card.Denfense;

        //参数传入Player类
        target.PlayerTakeDefense(dp);

        //检测卡牌携带的buff并触发
        foreach (var effect in currentSelectedCard.Card.BuffMessages)
        {
            effect.BuffEffect(target.gameObject);
        }

        Destroy(currentSelectedCard.gameObject);

        CancelSelection();
    }
}
