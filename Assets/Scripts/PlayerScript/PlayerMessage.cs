using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Player",menuName ="Data/Player")]
public class PlayerMessage : ScriptableObject
{
    public float MaxPlayerHP;
    public float CurrentPlayerHP;
    public float OriginPlayerDP;
    public float CurrentPlayerDP;

    public SpriteRenderer PlayerSprite;

    public List<BuffMessage> PlayerBuff;
}
