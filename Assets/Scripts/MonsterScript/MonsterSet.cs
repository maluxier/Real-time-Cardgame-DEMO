using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSet : MonoBehaviour
{
    public GameObject monsterPrefab;
    public Transform setArea;
    public MonsterInventery myInventery;
    
    // Start is called before the first frame update
    void Start()
    {
        SetMonster();
    }

    public void SetMonster()
    {
        int monsterID = Random.Range(0, myInventery.monstersList.Count);
        MonsterMessage data = myInventery.monstersList[monsterID];
        for(int i=0;i < setArea.childCount; i++)
        {
            if(setArea.GetChild(i).childCount == 0)
            {
                GameObject newMonster = Instantiate(monsterPrefab, setArea.GetChild(i));
                newMonster.GetComponent<MonsterCreat>().Init(data);
                Debug.Log("怪物已生成");
            }
            else
            {
                return;
            }
        }
        
    }
}
