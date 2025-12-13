using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxPlayerHP;
    public float currentPlayerHP;

    public float originPlayerDP;
    public float currentPlayerDP;

    public SpriteRenderer playerSprite;

    public bool isPlayerDead = false;
    
    public PlayerMessage playerMessage;


    /*数据初始化*/
    public void Init()
    {
        maxPlayerHP = playerMessage.MaxPlayerHP;
        currentPlayerHP = maxPlayerHP;

        originPlayerDP = playerMessage.OriginPlayerDP;
        currentPlayerDP = originPlayerDP;

        playerSprite = playerMessage.PlayerSprite;

        /*this.playerMessage = data;

        maxPlayerHP = data.MaxPlayerHP;
        currentPlayerHP = maxPlayerHP;

        originPlayerDP = data.OriginPlayerDP;
        currentPlayerDP = originPlayerDP;*/
    }

    public void PlayerTakeDamage(float Pdmg)
    {
        currentPlayerHP = currentPlayerHP - (Pdmg - currentPlayerDP);
        Debug.Log("玩家受击");
        if (currentPlayerHP <= 0)
        {
            isPlayerDead = true;
            PlayerDataBack();
            Destroy(this.gameObject);
        }

    }

    public void PlayerTakeDefense(float Pdp)
    {
        currentPlayerDP += Pdp;
    }

    /*此处我想写进入下一关前的数据回传*/
    public void PlayerDataBack()
    {
        
    }
}
