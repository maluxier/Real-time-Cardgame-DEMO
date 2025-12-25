using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterActionManager : MonoBehaviour
{
    public static MonsterActionManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }       
    }

    public void SkillRun(MonsterSkillMessage skill, GameObject monsterSelf, GameObject playerTarget)
    {
        if(skill == null)
        {
            return;
        }

        GameObject fineTarget = null;

        switch (skill.actionType)
        {
            case MonsterActionType.Attack:
                fineTarget = playerTarget;
                break;
            case MonsterActionType.Defense:
                fineTarget = monsterSelf;
                break;
        }

        if(fineTarget != null)
        {
            Debug.Log("怪物技能释放成功");
            skill.SkillEffect(fineTarget);
        }
        else
        {
            Debug.Log("怪物技能释放失败");
        }
    }
}
