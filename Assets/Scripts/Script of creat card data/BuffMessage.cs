using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffMessage : ScriptableObject
{
    public abstract void BuffEffect(GameObject buffTarget);
}
