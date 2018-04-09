using System;
using System.Collections;
using Script;
using UnityEngine;

namespace Assets.Script
{
	public class MainGameController : MonoBehaviour
	{
		public GameViewController GameViewController;
		public GameManager gameManager;
		public int timer;
		static Logic logic = new Logic();


		public void StartGame()
		{
			gameManager = new GameManager(logic);
			gameManager.SetWerewolfIndex();
			PlayerModel[] playerModelArray = new PlayerModel[6];
			int wereWolfIndex = gameManager.GetWerewolfIndex();
			for (int i = 0; i < 6; i++)
			{
				var enmPlayerId = (PlayerId)Enum.ToObject(typeof(PlayerId), i + 1);
				playerModelArray[i] = new PlayerModel(enmPlayerId, i == wereWolfIndex ? EnumRole.Werewolf : EnumRole.Citizen);
			}
			bool isCalled = false;
			gameManager.StartGame(() => isCalled = true);
			StartCoroutine(CountUpCoroutine());
			GameViewController.SetPlayers(playerModelArray);
			GameViewController.SetVote(PlayerId.Player1, PlayerId.Player2);
			GameViewController.SetVote(PlayerId.Player2, PlayerId.Player1);
			GameViewController.SetVotedNum(PlayerId.Player1, 3);
			GameViewController.SetVotedNum(PlayerId.Player2, 1);
		}

		private IEnumerator CountUpCoroutine()
		{
			Debug.Log("coroutine");
			while(true){
				GameViewController.SetTimer(timer++);
				logic.PassTime(timer);
				yield return new WaitForSeconds(1);
			};
		}
	}
}
