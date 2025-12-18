using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffCardTest", menuName = "buff/BuffCardTest")]
public class BuffCardTest : BuffMessage
{
    public float damageTick = 5f;//每次扣血量
    public float intervalTime = 2f;//扣血间隔时间

    public float tickTime;
    public override void BuffEffect(GameObject buffTarget)
    {
        Debug.Log("buff生效");
        MonsterCreat monster = buffTarget.GetComponent<MonsterCreat>();
        tickTime += Time.deltaTime;
        if(tickTime >= intervalTime)
        {
            monster.TakeDamage(damageTick);
            tickTime -= intervalTime;
        }
    }
}
