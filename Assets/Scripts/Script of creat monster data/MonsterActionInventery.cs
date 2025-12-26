using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New MonsterActInventery",menuName = "Data/New MonsterActInventery")]
public class MonsterActionInventery : ScriptableObject
{
    public  List<MonsterActionMessage> ActionList;
}
