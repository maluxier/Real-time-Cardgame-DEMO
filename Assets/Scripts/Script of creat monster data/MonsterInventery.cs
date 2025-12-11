using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New mstInventery",menuName ="Data/New mstInventery")]
public class MonsterInventery : ScriptableObject
{
    public  List<MonsterMessage> monstersList = new List<MonsterMessage>();
}
