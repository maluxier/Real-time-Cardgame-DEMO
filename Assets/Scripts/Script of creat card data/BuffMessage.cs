using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//buff触发类型
public enum BuffLifeType
{
    Duration,//持续buff
    OneShot//单次buff
}

//buff类型
public enum BuffType
{
    Neutral,//中性
    Radical,//激进
    Conservativeness//保守
}
public abstract class BuffMessage : ScriptableObject
{
    public bool isBuffGo;

    public float buffCD;
    public float currentBuffCD;

    public BuffType type;

    public BuffLifeType lifeType;//buff触发类型
    protected bool isTriggered;//用于检查单次buff是否已经触发


    //进入buff列表时被调用，初始化buff
    public void Init()
    {
        currentBuffCD = buffCD;
        isBuffGo = true;

        isTriggered = false;
    }

    /*判断是否要执行单次buff的效果*/
    public void ExrcuteType(GameObject buffTarget)
    {
        if (!isBuffGo) return;

        if (lifeType == BuffLifeType.OneShot)
        {
            if (isTriggered)
            {
                return;
            }

            BuffEffect(buffTarget);
            isTriggered = true;
        }
        else
        {
            BuffEffect(buffTarget);
        }
    }

    //向外传递一个此buff可以被删除的信号
    public bool BuffDel()
    {
        if (isBuffGo == false)
        {
            return false;
        }

        switch (lifeType)
        {
            case BuffLifeType.OneShot:
                return isTriggered;

            case BuffLifeType.Duration:
                currentBuffCD -= Time.deltaTime;
                if (currentBuffCD <= 0)
                {
                    isBuffGo = false;
                    return true;
                }
                break;
        }

        return false;
    }



    //此处为buff的机制编写处
    public abstract void BuffEffect(GameObject buffTarget);
}
