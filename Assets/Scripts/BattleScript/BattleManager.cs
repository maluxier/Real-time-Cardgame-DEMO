using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SelectCard(CardCreat mySelectCard)
    {
        
    }
}
