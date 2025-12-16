using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuffCardTest", menuName = "buff/BuffCardTest")]
public class BuffCardTest : BuffMessage
{
    public override void BuffEffect(GameObject buffTarget)
    {
        Debug.Log("buff…˙–ß");       
    }
}
