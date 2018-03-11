using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class StubGameViewController : MonoBehaviour
{
		public GameViewController gameViewController;


	public void ButtonSetPlayer()
	{
		PlayerModel[] PlayerModelArray = new PlayerModel[2];
		PlayerModelArray[0] = new PlayerModel(EnumPlayer.Player1, EnumRole.Citizen);
		PlayerModelArray[1] = new PlayerModel(EnumPlayer.Player2, EnumRole.Werewolf);
		gameViewController.SetTimer(3);
		gameViewController.SetPlayer(PlayerModelArray);
		gameViewController.SetVote(EnumPlayer.Player1, EnumPlayer.Player2);
		gameViewController.SetVote(EnumPlayer.Player2, EnumPlayer.Player1);
	}
}
