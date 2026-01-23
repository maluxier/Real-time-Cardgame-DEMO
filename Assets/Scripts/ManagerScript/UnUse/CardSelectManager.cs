using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CardSelectManager : MonoBehaviour
{
    public static CardSelectManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SelectCard(CardCreat card)
    {
        switch (card.CardClass)
        {
            case 0:
                BattleManager.instance.SelectCard(card); 
                break;
            case 1:
                DefenseManager.instance.SelectDefenseCard(card);
                break;
                //Temp Script//////////////
            case 2:
                DefenseManager.instance.SelectDefenseCard(card);
                break;
        }
    }
}
