using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int HP = 100;

    public void TakeDamage(int amount)
    {
        HP -= amount;
        Debug.Log("¹ÖÎïÊÜ»÷");
    }
}
