using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Healing", menuName = "buff/Healing")]
public class Healing : BuffMessage
{
    public float healingTick = 5f;//每次回血量
    public float intervalTime = 1f;//回血间隔时间

    public float tickTime;
    public override void BuffEffect(GameObject buffTarget)
    {
        Debug.Log("buff生效");
        Player player = buffTarget.GetComponent<Player>();
        tickTime += Time.deltaTime;
        if (tickTime >= intervalTime)
        {
            player.currentPlayerHP += healingTick;
            tickTime -= intervalTime;
        }
    }
}
