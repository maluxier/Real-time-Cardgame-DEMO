using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngineInternal;

[CreateAssetMenu(fileName = "NormalAttack", menuName = "buff/NormalAttack")]
public class NormalAttackBuff : BuffMessage
{
    public float baseDamage = 20f;
    public float finalDamage;
    public void OnEnable()
    {
        lifeType = BuffLifeType.OneShot;
    }

    public override void Calculate(BuffContext context)
    {
        float rate = 1f;
        rate += context.player.playerAttackRate;

        finalDamage = baseDamage * rate;
    }

    public override void BuffEffect(GameObject buffTarget)
    {
        buffTarget.GetComponent<MonsterCreat>().TakeDamage(finalDamage);
    }

    
}
