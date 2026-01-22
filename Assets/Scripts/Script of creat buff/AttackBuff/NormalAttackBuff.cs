using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

[CreateAssetMenu(fileName = "NormalAttack", menuName = "buff/NormalAttack")]
public class NormalAttackBuff : BuffMessage
{
    public float damage = 20f;

    public void OnEnable()
    {
        lifeType = BuffLifeType.OneShot;
    }
    public override void BuffEffect(GameObject buffTarget)
    {
       MonsterCreat monster = buffTarget.GetComponent<MonsterCreat>();
       monster.TakeDamage(damage);
    }
}
