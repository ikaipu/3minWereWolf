using System;
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
        for (int i = 0; i < 3; i++)
        {
            GameObject playerInst = GameObject.Instantiate(playerPrefab);
            playerInst.transform.SetParent(playerPrefabParent.transform);
            var enmPlayerId = PlayerIdExtensions.FromInt(i + 1);
            if (i < 3)
            {
                playerInst.transform.localPosition = new Vector3(i * 108 - 108, 123, 3);
            }
            else
            {
                playerInst.transform.localPosition = new Vector3((i - 3) * 108 - 108, -53, 3);
            }
            playerArray[i] = playerInst.GetComponent<PlayerController>();
            playerArray[i].IdText.text = enmPlayerId.ToName();
            playerArray[i].VotedNum.text = "0";
        }
    }

    public void SetPlayers(PlayerModel[] playerModelArray, GameManager gameManager)
    {
        for (int i = 0; i < 3; i++)
        {
            playerArray[i].Set(playerModelArray[i], playerId =>
            {
                gameManager.SetVoteTarget(0, int.Parse(playerId) - 1);
                for (int j = 0; j < 3; j++)
                {
                    playerArray[j].SetVotedNum(gameManager.GetVotedNum(j));
                }
            });
        }
    }

    public void SetTimer(int time)
    {
        timer.text = time.ToString();
    }

    public void SetVote(PlayerId from, PlayerId to)
    {
        var player = playerArray.First(p => p.IdText.text == from.ToString());
        player.SetVoteTo();
    }

    public void SetVotedNum(PlayerId playerId, int votedNum)
    {
        var player = playerArray.First(p => p.IdText.text == playerId.ToString());
        player.SetVotedNum(votedNum);
    }
}