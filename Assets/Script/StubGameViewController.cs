using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class StubGameViewController : MonoBehaviour
{
	public GameViewController gameViewController;


	public void ButtonSetPlayer()
	{
		PlayerModel[] PlayerModelArray = new PlayerModel[3];
		PlayerModelArray[0] = new PlayerModel(PlayerId.Player1, EnumRole.Citizen);
		PlayerModelArray[1] = new PlayerModel(PlayerId.Player2, EnumRole.Werewolf);
		PlayerModelArray[2] = new PlayerModel(PlayerId.Player3, EnumRole.Citizen);
//		PlayerModelArray[3] = new PlayerModel(PlayerId.Player4, EnumRole.Citizen);
//		PlayerModelArray[4] = new PlayerModel(PlayerId.Player5, EnumRole.Citizen);
//		PlayerModelArray[5] = new PlayerModel(PlayerId.Player6, EnumRole.Citizen);
		gameViewController.SetTimer(3);
		gameViewController.SetPlayers(PlayerModelArray);
		gameViewController.SetVote(PlayerId.Player1, PlayerId.Player2);
		gameViewController.SetVote(PlayerId.Player2, PlayerId.Player1);
		gameViewController.SetVotedNum(PlayerId.Player1, 3);
		gameViewController.SetVotedNum(PlayerId.Player2, 1);
	}
}
