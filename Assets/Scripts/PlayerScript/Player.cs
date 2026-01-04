using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxPlayerHP;
    public float currentPlayerHP;

    public float originPlayerDP;
    public float currentPlayerDP;

    public SpriteRenderer playerSprite;

    public bool isPlayerDead = false;
    
    public PlayerMessage playerMessage;

    public List<BuffMessage> playerBuff;


    public Image hpFill;

    private void Update()
    {
        HPVisiable();
        for (int i = playerBuff.Count-1; i >= 0; i--)
        {
            BuffMessage buff = playerBuff[i];

            buff.BuffEffect(this.gameObject);

            if (buff.BuffDel())
            {
                playerBuff.RemoveAt(i);
            }
        }
    }


    /*数据初始化*/
    public void Init()
    {
        maxPlayerHP = playerMessage.MaxPlayerHP;
        currentPlayerHP = maxPlayerHP;

        originPlayerDP = playerMessage.OriginPlayerDP;
        currentPlayerDP = originPlayerDP;

        playerSprite = playerMessage.PlayerSprite;

        playerBuff = playerMessage.PlayerBuff;

        HPVisiable();
    }

    public void PlayerTakeDamage(float Pdmg)
    {
        if(currentPlayerDP >= Pdmg)
        {
            currentPlayerDP -= Pdmg;
            Pdmg = 0;
        }
        else
        {
            Pdmg -= currentPlayerDP;
            currentPlayerDP = 0;
        }

        currentPlayerHP -= Pdmg;
        
        Debug.Log("玩家受击");
        if (currentPlayerHP <= 0)
        {
            isPlayerDead = true;
            PlayerDataBack();
            gameObject.SetActive(false);
            this.enabled = false;
        }

    }

    public void PlayerTakeDefense(float Pdp)
    {
        currentPlayerDP += Pdp;
    }

    public void DelMyBuff()
    {
        foreach (var item in playerBuff)
        {

        }
    }

    public void HPVisiable()
    {
        hpFill.fillAmount = currentPlayerHP/maxPlayerHP;
    }

    /*此处我想写进入下一关前的数据回传*/
    public void PlayerDataBack()
    {
        
    }
}
