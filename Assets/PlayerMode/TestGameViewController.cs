using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Script;

public class TestGameViewController {

	[Test]
	public void TestGameViewControllerSimplePasses()
	{
		GameObject gameViewPrefab = Resources.Load<GameObject>("GameView");
		GameViewController gameViewController = GameObject.Instantiate(gameViewPrefab).GetComponent<GameViewController>();
		PlayerModel[] PlayerModelArray = new PlayerModel[2];
		PlayerModelArray[0] = new PlayerModel(EnumPlayer.Player1, EnumRole.Citizen);
		PlayerModelArray[1] = new PlayerModel(EnumPlayer.Player2, EnumRole.Werewolf);
		gameViewController.SetPlayer(PlayerModelArray);
		
		Assert.AreEqual(gameViewController.playerArray[0].IdText.text, EnumPlayer.Player1.ToString());
		Assert.AreEqual(gameViewController.playerArray[0].RoleText.text,EnumRole.Citizen.ToString());
		Assert.AreEqual(gameViewController.playerArray[1].IdText.text,EnumPlayer.Player2.ToString());
		Assert.AreEqual(gameViewController.playerArray[1].RoleText.text,EnumRole.Werewolf.ToString());

		gameViewController.SetTimer(35);
		Assert.AreEqual(gameViewController.timer.text, "35");

		gameViewController.SetVote(EnumPlayer.Player1, EnumPlayer.Player2);
		gameViewController.SetVote(EnumPlayer.Player2, EnumPlayer.Player1);
		
		Assert.AreEqual(gameViewController.playerArray[0].VoteTo.text, EnumPlayer.Player2.ToString());
		Assert.AreEqual(gameViewController.playerArray[1].VoteTo.text, EnumPlayer.Player1.ToString());
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
