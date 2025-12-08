using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreat : MonoBehaviour
{
    public MonsterMessage monster;

    public int monsterClass;

    public float monsterMaxHP;
    public float monsterCurrentHP;

    public float monsterAttack;

    public void Init(MonsterMessage data)
    {
        this.monster = data;

        monsterClass = data.MonsterClass;
        monsterMaxHP = data.MonsterMaxHP;
        monsterCurrentHP = monsterMaxHP;
        monsterAttack = data.MonsterAttack;

    }


    public void TakeDamage(int amount)
    {
        monsterCurrentHP -= amount;
        Debug.Log("π÷ŒÔ ‹ª˜");
    }

    public void MonsterDie()
    {
        if(monsterCurrentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
