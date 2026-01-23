using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player",menuName ="Data/Player")]
public class PlayerMessage : ScriptableObject
{
    [Header("基础信息")]
    public float MaxPlayerHP;
    public float CurrentPlayerHP;
    public float OriginPlayerDP;
    public float CurrentPlayerDP;

    [Header("攻击倍率")]
    public float attackRateBonus = 1f;


    public Sprite PlayerSprite;

    public List<BuffMessage> PlayerBuff;
}
