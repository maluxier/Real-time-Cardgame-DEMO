using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CardClassifyScript : MonoBehaviour
{
    [Header("¹Ø¿¨×Ü¿¨ÅÆ¿â")]
    public CardInventery myCardInventery;

    [Header("·ÖÀà¿¨ÅÆ¿â")]
    public CardInventery attackCardInventery;
    public CardInventery defenseCardInventery;
    public CardInventery buffCardInventery;


    private void Awake()
    {
        if(attackCardInventery != null)attackCardInventery.cardList.Clear();
        if(defenseCardInventery != null)defenseCardInventery.cardList.Clear();
        if(buffCardInventery != null)buffCardInventery.cardList.Clear();
        Classify();
    }


    public void Classify()
    {
        for (int i = 0; i < myCardInventery.cardList.Count; i++)
        {
            var currentCard = myCardInventery.cardList[i];
            switch (myCardInventery.cardList[i].CardClass)
            {
                case 0:                    
                    attackCardInventery.cardList.Add(currentCard);
                    break;
                case 1:                    
                    defenseCardInventery.cardList.Add(currentCard);
                    break;
                case 2:                    
                    buffCardInventery.cardList.Add(currentCard);
                    break;
            }
        }
    }
}
