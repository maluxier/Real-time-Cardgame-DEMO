using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSet : MonoBehaviour
{
    public Transform playerTransfrom;
    public GameObject playerPrefab;

    private void Start()
    {
        SetPlayer();
    }

    public void SetPlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab, playerTransfrom);
        newPlayer.GetComponent<Player>().Init();
        Debug.Log("玩家已生成");
    }
}
