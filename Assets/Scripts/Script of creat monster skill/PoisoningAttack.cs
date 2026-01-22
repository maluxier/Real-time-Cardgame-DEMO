using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PoisoningAttack", menuName = "MonsterSkill/PoisoningAttack")]
public class PoisoningAttack : MonsterSkillMessage
{
    public override void SkillEffect(GameObject target)
    {
        Player player = target.GetComponent<Player>();

    }
}
