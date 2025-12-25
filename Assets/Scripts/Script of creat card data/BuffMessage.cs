using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    //进入buff列表时被调用，初始化buff
    public void Init()
    {
        currentBuffCD = buffCD;
        isBuffGo = true;
    }

    //向外传递一个此buff可以被删除的信号
    public bool BuffDel()
    {
        if (isBuffGo == false)
        {
            return false;
        }

        currentBuffCD -= Time.deltaTime;
        if (currentBuffCD <= 0)
        {
            isBuffGo = false;
            return true;
        }

        return false;
    }

    //此处为buff的机制编写处
    public abstract void BuffEffect(GameObject buffTarget);
}
