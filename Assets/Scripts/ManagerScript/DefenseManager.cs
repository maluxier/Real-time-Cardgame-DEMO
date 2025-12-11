using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseManager : MonoBehaviour
{
    public static DefenseManager instance;

    public Camera mainCamera;
    public LayerMask playerLayer;


    private CardCreat currentSelectedCard;
    public bool isTargeting;

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
                DetectPlayerClick();
            }
        }

        if (isTargeting && Input.GetMouseButtonDown(1))
        {
            CancelSelection();
        }
    }

    public void SelectCard(CardCreat mySelectCard)
    {

        currentSelectedCard = mySelectCard;
        isTargeting = true;
        Debug.Log("已选中卡牌");
    }

    private void CancelSelection()//取消对当前卡牌的选择
    {
        currentSelectedCard = null;
        isTargeting = false;

    }

    private void DetectPlayerClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);//从摄像机发射射线检测当前点击的是不是怪
        RaycastHit hit;//检测射线击中的物体，设置为hit变量

        if (Physics.Raycast(ray, out hit, 100f, playerLayer))
        {
            Debug.Log(hit.collider.name);
            MonsterCreat target = hit.collider.GetComponent<MonsterCreat>();
            if (target != null)
            {
                Defense();
                Debug.Log("防御");
            }
        }
        else
        {
            //没选中怪物则重置选择状态
            CancelSelection();
            Debug.Log("没点中玩家");
        }
    }

    public void Defense()
    {
        if (currentSelectedCard != null)
        {
            return;
        }
        
    }
}
