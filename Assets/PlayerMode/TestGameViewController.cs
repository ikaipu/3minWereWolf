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
		PlayerModelArray[0] = new PlayerModel(1, EnumRole.Citizen);
		PlayerModelArray[1] = new PlayerModel(2, EnumRole.Werewolf);
		gameViewController.SetPlayer(PlayerModelArray);
		
		Assert.AreEqual(gameViewController.playerArray[0].IdText.text,"Player1");
		Assert.AreEqual(gameViewController.playerArray[0].RoleText.text,EnumRole.Citizen);
		Assert.AreEqual(gameViewController.playerArray[1].IdText.text,"Player2");
		Assert.AreEqual(gameViewController.playerArray[1].RoleText.text,EnumRole.Werewolf);

		gameViewController.SetTimer(35);
		Assert.AreEqual(gameViewController.timer.text, "35");

		gameViewController.playerArray[0].AddVoter("Player2");
		gameViewController.playerArray[1].AddVoter("Player1");
		gameViewController.playerArray[1].AddVoter("Player3");
		
		Assert.AreEqual(gameViewController.playerArray[0].VoterList.text, "Player2\n");
		Assert.AreEqual(gameViewController.playerArray[1].VoterList.text, "Player1\nPlayer3\n");

		gameViewController.playerArray[1].RemoveVoter("Player1");

		Assert.AreEqual(gameViewController.playerArray[1].VoterList.text, "Player3\n");
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
