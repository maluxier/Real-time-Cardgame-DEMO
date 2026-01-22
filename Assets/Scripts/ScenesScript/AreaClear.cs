using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*这是一个临时代码！！*/
public class AreaClear : MonoBehaviour
{
    // 用来存放那三个怪物容器（Monster1, Monster2, Monster3）
    public Transform[] monsterContainers;

    public Transform playerArea;//temp

    // 要切换去的场景名字
    public string nextSceneName = "WinScene";

    // 一个开关，防止游戏结束那一瞬间重复调用切场景
    private bool isLevelCleared = false;

    void Update()
    {
        // 如果已经通关了，就别再检查了，省点性能
        if (isLevelCleared) return;

        // 检查是否所有容器都空了
        if (CheckIfAllEmpty())
        {
            Debug.Log("所有怪物已清除！游戏胜利！");
            isLevelCleared = true; // 锁住状态

            // 切换场景
            SceneManager.LoadScene(nextSceneName);
        }

        if (CheckPlayerDead())
        {
            Debug.Log("所有怪物已清除！游戏胜利！");
            isLevelCleared = true; // 锁住状态

            // 切换场景
            SceneManager.LoadScene(nextSceneName);
        }
    }

    bool CheckPlayerDead()
    {
        if(playerArea.childCount > 0)
        {
            return false;
        }
        return true;
    }

    // 这是一个自定义方法，用来检查是否所有容器都空了
    bool CheckIfAllEmpty()
    {
        // 遍历每一个容器
        foreach (Transform container in monsterContainers)
        {
            // 只要有一个容器里还有子物体（childCount > 0）
            // 说明还没清空，直接返回 false
            if (container.childCount > 0)
            {
                return false;
            }
        }

        // 如果循环跑完了都没返回 false，说明所有容器的 childCount 都是 0
        return true;
    }
}
