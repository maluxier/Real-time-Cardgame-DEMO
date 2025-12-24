using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.UI;
public class MonsterCreat : MonoBehaviour
{
    public MonsterMessage monster;

    public int monsterClass;

    public float monsterMaxHP;
    public float monsterCurrentHP;
    public SpriteRenderer monsterImage;

    public float monsterAttack;

    public List<BuffMessage> monsterBuff;

    public List<MonsterSkillMessage> attackSkill;//攻击技能
    public List<MonsterSkillMessage> defenseSkill;//保守技能

    public Image hpFill;


    private void Update()
    {
        //检测怪物携带buff的触发状况
        if(monsterBuff == null)
        {
            return;
        }
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

        //初始化本怪物技能列表
        attackSkill = new List<MonsterSkillMessage>();
        defenseSkill = new List<MonsterSkillMessage>();
        
        //初始化怪物数据
        this.monster = data;

        monsterClass = data.MonsterClass;
        monsterMaxHP = data.MonsterMaxHP;
        monsterCurrentHP = monsterMaxHP;
        monsterAttack = data.MonsterAttack;
        monsterImage = data.MonsterImage;

        hpVisiable();

        //将怪物拥有的技能分类
        for (int i = 0; i < monster.MonsterSkill.Count; i++)
        {
            switch (monster.MonsterSkill[i].actionType)
            {
                case MonsterActionType.Attack:
                    attackSkill.Add(monster.MonsterSkill[i]);
                    break;
                case MonsterActionType.Defense:
                    defenseSkill.Add(monster.MonsterSkill[i]);
                    break;
            }
        }
    }

    //怪物受击代码
    public void TakeDamage(float amount)
    {
        monsterCurrentHP -= amount;
        hpVisiable();
        Debug.Log("怪物受击");
        if (monsterCurrentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void hpVisiable()
    {
        hpFill.fillAmount = monsterCurrentHP / monsterMaxHP;
    }
}
