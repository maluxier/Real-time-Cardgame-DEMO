using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreat : MonoBehaviour
{
    public MonsterMessage monster;

    public int monsterClass;

    public float monsterMaxHP;
    public float monsterCurrentHP;
    public SpriteRenderer monsterImage;

    public float monsterAttack;

    public List<BuffMessage> monsterBuff;

    private void Update()
    {
        for (int i = monsterBuff.Count - 1; i >= 0; i--)
        {
            BuffMessage buff = monsterBuff[i];
            buff.BuffEffect(this.gameObject);

            if (buff.BuffDel())
            {
                monsterBuff.RemoveAt(i);
            }
        }
    }

    public void Init(MonsterMessage data)
    {
        this.monster = data;

        monsterClass = data.MonsterClass;
        monsterMaxHP = data.MonsterMaxHP;
        monsterCurrentHP = monsterMaxHP;
        monsterAttack = data.MonsterAttack;
        monsterImage = data.MonsterImage;
    }


    public void TakeDamage(float amount)
    {
        monsterCurrentHP -= amount;
        Debug.Log("π÷ŒÔ ‹ª˜");
        if (monsterCurrentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
