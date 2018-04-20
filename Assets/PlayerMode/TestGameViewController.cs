using System;
using UnityEngine;
using NUnit.Framework;
using Script;

public class TestGameViewController {
	[Test]
	public void TestGameViewControllerSimplePasses()
	{
		ILogic logic = new Logic();
		GameManager gameManager = new GameManager(logic);
		GameObject gameViewPrefab = Resources.Load<GameObject>("GameView");
		GameViewController gameViewController = GameObject.Instantiate(gameViewPrefab).GetComponent<GameViewController>();
		PlayerModel[] PlayerModelArray = new PlayerModel[2];
		PlayerModelArray[0] = new PlayerModel(PlayerId.Player1, EnumRole.Citizen);
		PlayerModelArray[1] = new PlayerModel(PlayerId.Player2, EnumRole.Citizen);
		PlayerModelArray[2] = new PlayerModel(PlayerId.Player3, EnumRole.Citizen);
//		PlayerModelArray[3] = new PlayerModel(PlayerId.Player4, EnumRole.Werewolf);
//		PlayerModelArray[4] = new PlayerModel(PlayerId.Player5, EnumRole.Citizen);
//		PlayerModelArray[5] = new PlayerModel(PlayerId.Player6, EnumRole.Citizen);
		gameViewController.SetPlayers(PlayerModelArray, gameManager);
		
		Assert.AreEqual(gameViewController.playerArray[0].IdText.text, PlayerId.Player1.ToString());
		Assert.AreEqual(gameViewController.playerArray[0].RoleText.text, EnumRole.Citizen.ToString());
		Assert.AreEqual(gameViewController.playerArray[1].IdText.text, PlayerId.Player2.ToString());
		Assert.AreEqual(gameViewController.playerArray[1].RoleText.text, EnumRole.Werewolf.ToString());

		gameViewController.SetTimer(35);
		Assert.AreEqual(gameViewController.timer.text, "35");

		gameViewController.SetVote(PlayerId.Player1, PlayerId.Player2);
		gameViewController.SetVote(PlayerId.Player2, PlayerId.Player1);
		
		Assert.AreEqual(gameViewController.playerArray[0].VoteTo.text, PlayerId.Player2.ToString());
		Assert.AreEqual(gameViewController.playerArray[1].VoteTo.text, PlayerId.Player1.ToString());

		gameViewController.SetVotedNum(PlayerId.Player1, 2);
		gameViewController.SetVotedNum(PlayerId.Player2, 1);
		
		Assert.AreEqual(gameViewController.playerArray[0].VotedNum.text, "2");
		Assert.AreEqual(gameViewController.playerArray[1].VotedNum.text, "1");
	}

//	// A UnityTest behaves like a coroutine in PlayMode
//	// and allows you to yield null to skip a frame in EditMode
//	[UnityTest]
//	public IEnumerator TestGameViewControllerWithEnumeratorPasses() {
//		// Use the Assert class to test conditions.
//		// yield to skip a frame
//		yield return null;
//	}
}
