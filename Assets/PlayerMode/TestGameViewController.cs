using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestGameViewController {

	[Test]
	public void TestGameViewControllerSimplePasses()
	{
		GameObject gameViewPrefab = Resources.Load<GameObject>("GameView");
		GameViewController gameViewController = GameObject.Instantiate(gameViewPrefab).GetComponent<GameViewController>();
		PlayerModel[] PlayerModelArray = new PlayerModel[2];
		PlayerModelArray[0] = new PlayerModel(1, "Citizen");
		PlayerModelArray[1] = new PlayerModel(2, "Werewolf");
		gameViewController.SetPlayer(PlayerModelArray);
		
		Assert.AreEqual(gameViewController.playerArray[0].IdText.text,"Player1");
		Assert.AreEqual(gameViewController.playerArray[0].RoleText.text,"Citizen");
		Assert.AreEqual(gameViewController.playerArray[1].IdText.text,"Player2");
		Assert.AreEqual(gameViewController.playerArray[1].RoleText.text,"Werewolf");

		gameViewController.SetTimer(35);
		Assert.AreEqual(gameViewController.timer.text, "35");

		gameViewController.playerArray[0].SetVoter("Player2");
		gameViewController.playerArray[1].SetVoter("Player1");
		gameViewController.playerArray[1].SetVoter("Player3");
		
		CollectionAssert.AreEqual(playerArray[0].voters, new []{"Player2"});
		CollectionAssert.AreEqual(playerArray[1].voters, new []{"Player1", "Player3"});
		
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
