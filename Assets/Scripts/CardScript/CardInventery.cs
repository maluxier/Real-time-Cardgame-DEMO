using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Inventery" ,menuName = "Inventery")]
public class CardInventery : ScriptableObject
{
   public List<CardMessage> cardList = new List<CardMessage>();
}
