using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterAI : MonoBehaviour
{
    public float baseAttackWeight;
    public float baseDefenseWeight;

    private MonsterCreat monsterData;

    private void Awake()
    {
        monsterData = GetComponent<MonsterCreat>();
    }


    //加权随机决策算法
    public MonsterSkillMessage DecideAction()
    {
        //初始化权重
        float currentAttackWeight = baseAttackWeight;
        float currentDefenseWeight = baseDefenseWeight;   

        float HPPercent = (float)monsterData.monsterCurrentHP/monsterData.monsterMaxHP;//怪物血量百分比

        if (HPPercent > 0.7f)
        {
            currentAttackWeight += 30f;
        }

        if (HPPercent < 0.3f)
        {
            currentDefenseWeight += 50f;
        }

        //buff类型影响权重
        foreach(var buff in monsterData.monsterBuff)
        {
            switch (buff.type)
            {
                case BuffType.Radical:
                    currentAttackWeight += 20f;
                    break;

                case BuffType.Conservativeness:
                    currentDefenseWeight += 20f;
                    break;
            }
        }

        float totalWeight = currentAttackWeight + currentDefenseWeight;//随机数宽度
        float randomValue = Random.Range(0, totalWeight);

        MonsterActionType selectType;//选择的行动类型

        if (randomValue <= currentAttackWeight)
        {
            selectType = MonsterActionType.Attack;
        }
        else
        {
            selectType = MonsterActionType.Defense;
        }

        return GetMonsterActionType(selectType);
    }

    //接收随机到的技能类型来调用技能
    private MonsterSkillMessage GetMonsterActionType(MonsterActionType monsterActionType)
    {
        List<MonsterSkillMessage> targetList = null;//临时列表，储存接下来要随机抽取的技能类型

        if (monsterActionType == MonsterActionType.Attack)
        {
            targetList = monsterData.attackSkill;
        }
        else if(monsterActionType == MonsterActionType.Defense)
        {
            targetList= monsterData.defenseSkill;
        }

        //安全检查
        if (targetList == null || targetList.Count == 0)
        {
            return null;
        }
        
        int randomSkill = Random.Range(0, targetList.Count);

        return targetList[randomSkill];
    }
}
