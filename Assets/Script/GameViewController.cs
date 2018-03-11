using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Script;
using UnityEngine;
using UnityEngine.UI;

public class GameViewController : MonoBehaviour
{
    public Text timer;
    public PlayerController[] playerArray;
    public GameObject playerPrefab;
    public GameObject playerPrefabParent;

    private void Awake()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject playerInst = GameObject.Instantiate(playerPrefab);
            playerInst.transform.SetParent(playerPrefabParent.transform);
            playerInst.transform.localPosition = new Vector3(i * 108 - 108, 123, 3);
            playerArray[i] = playerInst.GetComponent<PlayerController>();
            playerArray[i].IdText.text = "Player" + (i + 1);
            playerArray[i].VotedNum.text = "0";
        }
    }

    public void SetPlayer(PlayerModel[] playerModelArray)
    {
        for (int i = 0; i < 2; i++)
        {
//            PlayerController playerController = GetComponent<PlayerController>();
            playerArray[i].Set(playerModelArray[i]);
        }
    }

    public void SetTimer(int time)
    {
        timer.text = time.ToString();
    }

    public void SetVote(EnumPlayer from, EnumPlayer to)
    {
        var player = playerArray.First(p => p.IdText.text == from.ToString());
        player.SetVoteTo(to);
    }

    public void SetVotedNum(EnumPlayer enumPlayer, int votedNum)
    {
        var player = playerArray.First(p => p.IdText.text == enumPlayer.ToString());
        player.SetVotedNum(votedNum);
    }
}