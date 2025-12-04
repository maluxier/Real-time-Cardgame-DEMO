using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.ExceptionServices;
using UnityEngine;

[CreateAssetMenu(fileName ="New monster", menuName ="Data/New monster")]
public class MonserMessage : ScriptableObject
{
    [Header("怪物种类")]
    public int MonserClass;

    [Header("怪物生命数值")]
    public float HP;//当前血量
    public float MaxHP;//血量上限

    [Header("怪物攻击数值")]
    public float MonsterAttack;
}
