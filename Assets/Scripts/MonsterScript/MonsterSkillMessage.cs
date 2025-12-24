using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterActionType
{
    Attack,
    Defense
}

[CreateAssetMenu(fileName ="New MonsterSkill",menuName ="MonsterSkill/New MonsterSkill")]
public abstract class MonsterSkillMessage : ScriptableObject
{
    public string skillName;
    public MonsterActionType actionType;

    public abstract void SkillEffect(GameObject target);
}
