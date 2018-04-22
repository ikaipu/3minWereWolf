using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Assets.Script;
using Script;

public class TestFirebaseController {

	[Test]
	public void TestFirebaseControllerSimplePasses() {
		GameObject gameObject = new GameObject();
		FirebaseController fc = gameObject.AddComponent<FirebaseController>();
		Assert.AreEqual("", "");
		PlayerModel[] playerModelArray = new PlayerModel[2];
		playerModelArray[0] = new PlayerModel(PlayerId.Player1, EnumRole.Citizen);
		playerModelArray[1] = new PlayerModel(PlayerId.Player2, EnumRole.Werewolf);
		fc.SetPlayers(playerModelArray);
	}
}
