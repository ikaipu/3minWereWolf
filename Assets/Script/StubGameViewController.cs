using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StubGameViewController : MonoBehaviour
{
		public GameViewController gameViewController;


	public void ButtonSetPlayer()
	{
		PlayerModel[] PlayerModelArray = new PlayerModel[2];
		PlayerModelArray[0] = new PlayerModel(1, "Citizen");
		PlayerModelArray[1] = new PlayerModel(2, "Werewolf");
		gameViewController.SetTimer(3);
		gameViewController.SetPlayer(PlayerModelArray);
	}
}
