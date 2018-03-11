using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameViewController : MonoBehaviour
{
    public Text timer;
    public PlayerController[] playerArray;

    public void SetPlayer(PlayerModel[] playerModelArray)
    {
        for (int i = 0; i < 2; i++)
        {
            PlayerController playerController = playerArray[i].GetComponent<PlayerController>();
            playerController.Set(playerModelArray[i]);
        }
    }

    public void SetTimer(int time)
    {
        timer.text = time.ToString();
    }
}