using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[CreateAssetMenu(fileName ="New monster", menuName ="Data/New monster")]
public class MonsterMessage : ScriptableObject
{
    [Header("怪物种类")]
    public int MonsterClass;

    [Header("怪物生命数值")]
    public float MonsterMaxHP;//血量上限

    [Header("怪物攻击数值")]
    public float MonsterAttack;/*有技能的化考虑删除*/

    [Header("怪物图片")]
    public SpriteRenderer MonsterImage;

    [Header("怪物技能")]
    public List<MonsterSkillMessage> MonsterSkill;
}
