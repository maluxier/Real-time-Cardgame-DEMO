using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "NewCard" , menuName = "Data/NewCard")]
public class CardMessage : ScriptableObject
{
    public int CardClass;
    public string CardName;
    public Sprite CardImage;

    public float Damage;

    public float Denfense;

    [TextArea]
    public string CardInfo;

    public List<BuffMessage> BuffMessages;
}
