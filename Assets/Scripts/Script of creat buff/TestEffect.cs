using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "testEffect",menuName = "buff/testEffect")]
public class TestEffect : BuffMessage
{
    public override void BuffEffect(GameObject buffTarget)
    {
        Debug.Log("buff…˙–ß¡À");
    }
}
