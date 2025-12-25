using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MonsterAttack",menuName ="MonsterSkill/MonsterAttack")]
public class MonsterAttack : MonsterSkillMessage
{
    public float damage;

    public override void SkillEffect(GameObject target)
    {
        Player player = target.GetComponent<Player>();
        player.PlayerTakeDamage(damage);
    }
}
