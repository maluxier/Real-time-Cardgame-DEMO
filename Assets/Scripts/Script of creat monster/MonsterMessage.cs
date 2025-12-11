using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.ExceptionServices;
using UnityEngine;

[CreateAssetMenu(fileName ="New monster", menuName ="Data/New monster")]
public class MonsterMessage : ScriptableObject
{
    [Header("怪物种类")]
    public int MonsterClass;

    [Header("怪物生命数值")]
    public float MonsterMaxHP;//血量上限

    [Header("怪物攻击数值")]
    public float MonsterAttack;

    [Header("怪物图片")]
    public SpriteRenderer MonsterImage;
}
