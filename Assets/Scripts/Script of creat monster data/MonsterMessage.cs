using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public enum MonsterClass
{
    Normal,
    Elite,
    Boss
}

[CreateAssetMenu(fileName ="New monster", menuName ="Data/New monster")]
public class MonsterMessage : ScriptableObject
{
    [Header("怪物种类")]
    public MonsterClass MonsterClass;

    [Header("怪物生命数值")]
    public float MonsterMaxHP;//血量上限

    [Header("怪物出招CD")]
    public float MosterActionCD;

    [Header("怪物图片")]
    public Sprite MonsterImage;

    [Header("怪物技能")]
    public List<MonsterSkillMessage> MonsterSkill;
}
