using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    public Camera mainCamera;

    public CardCreat mySelectCard;
    public bool isTargetting;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (isTargetting && Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            CancelSelectCard();
        }
    }

    public void CheckClick()
    {
        if (!isTargetting || mySelectCard == null) return;

        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (hit.collider == null) return;

        if (hit.collider.CompareTag("Monster"))
        {
            Debug.Log("点击怪物");
            GameObject monster = hit.collider.gameObject;
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            CardRun(player, monster);
        }
        else if (hit.collider.CompareTag("Player"))
        {
            GameObject player = hit.collider.gameObject;
            CardRun(player, null);
        }
    }

    public void SelectCard(CardCreat card)
    {
        mySelectCard = card;
        isTargetting = true;
        Debug.Log("已选中卡牌");
    }

    public void CancelSelectCard()
    {
        mySelectCard = null;
        isTargetting = false;       
    }
    
    public void CardRun(GameObject playerObj, GameObject monsterObj)
    {   
        if(mySelectCard == null) return ;

        Player player = playerObj.GetComponent<Player>();
        MonsterCreat monster = monsterObj ? monsterObj.GetComponent<MonsterCreat>() : null;

        BuffContext context = new BuffContext
        {
            player = player,
            card = mySelectCard.Card
        };

        foreach(var buffSO in mySelectCard.Card.BuffMessages)
        {
            BuffMessage buff = Instantiate(buffSO);
            buff.Init();

            buff.Calculate(context);

            switch (buff.targetType)
            {
                case BuffTargetType.Monster:
                    if(monster != null)
                    {
                        monster.monsterBuff.Add(buff);
                    }                    
                    break;
                case BuffTargetType.Player:
                    player.playerBuff.Add(buff);
                    break;
                case BuffTargetType.Both:
                    player.playerBuff.Add(buff);
                    if(monster != null)
                    {
                        BuffMessage buffForMonster = Instantiate(buff);
                        buffForMonster.Init();
                        buffForMonster.Calculate(context);
                        monster.monsterBuff.Add(buffForMonster);
                    }
                    break;
            }
        }

        Destroy(mySelectCard.gameObject);

        CancelSelectCard();

        Debug.Log("已触发卡牌");
    }
}
