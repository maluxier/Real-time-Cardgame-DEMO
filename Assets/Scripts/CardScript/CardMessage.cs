using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "NewCard" , menuName = "Card")]
public class CardMessage : ScriptableObject
{
    public int CardClass;
    public Text CardName;
    public Sprite CardImage;
    public Text CardInfo;
}
