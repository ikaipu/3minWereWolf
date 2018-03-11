using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEditor.VersionControl;
using UnityEngine.Assertions.Must;

public class TestGameManager {
	[Test]
	public void TestGameManagerSimplePasses()
	{
		LogicHolder.isMock = true;
		LogicMock logicMock = new LogicMock(0);
		GameManager gameManager = new GameManager(logicMock);

		gameManager.SetWerewolfIndex();

		Assert.AreEqual(0,gameManager.GetWerewolfIndex());

		bool isCalled = false;
		gameManager.StartGame(delegate()
		{
			//60秒経過後呼ばれる
			isCalled = true;
		});
		Assert.AreEqual(isCalled,false);
		//60秒経過処理
		logicMock.PassTime(59);
		Assert.AreEqual(isCalled,false);
		logicMock.PassTime(1);		
		Assert.AreEqual(isCalled,true);
		
		Assert.AreEqual(gameManager.GetTargetDictionary()[0],-1);
		gameManager.SetVoteTarget(0, 1);
		Assert.AreEqual(gameManager.GetTargetDictionary()[0],1);
		Assert.AreEqual(gameManager.GetKillTarget(),-1);
		gameManager.SetKillTarget(2);
		Assert.AreEqual(gameManager.GetKillTarget(),2);
		
		gameManager.SetVoteTarget(0, 1);
		gameManager.SetVoteTarget(1, 2);
		gameManager.SetVoteTarget(2, 3);
		gameManager.SetVoteTarget(3, 2);
		gameManager.SetVoteTarget(4, 2);
		gameManager.SetVoteTarget(5, 1);

		Assert.AreEqual(gameManager.GetMostVotedIndex(), 2);
		
		Assert.AreEqual("", gameManager.GetWinner());
		
		gameManager.Kill(1);
		gameManager.Kill(4);
		
		int[] expected = {1, 4};
		Assert.IsTrue(expected.SequenceEqual(gameManager.GetDeadList()));

		gameManager.Kill(0);
		Assert.AreEqual("Citizen", gameManager.GetWinner());
		LogicHolder.isMock = false;
	}
	
	[Test]
	public void TestGameManagerSimplePasses2()
	{
		LogicHolder.isMock = true;
		LogicMock logicMock = new LogicMock(0);
		GameManager gameManager = new GameManager(logicMock);

		gameManager.SetWerewolfIndex();

		Assert.AreEqual(0,gameManager.GetWerewolfIndex());
		
		Assert.AreEqual("", gameManager.GetWinner());
		gameManager.Kill(1);
		Assert.AreEqual("", gameManager.GetWinner());
		gameManager.Kill(2);
		Assert.AreEqual("", gameManager.GetWinner());
		gameManager.Kill(3);
		Assert.AreEqual("", gameManager.GetWinner());
		gameManager.Kill(4);
		Assert.AreEqual("", gameManager.GetWinner());
		gameManager.Kill(5);
		
		Assert.AreEqual("Werewolf", gameManager.GetWinner());
		LogicHolder.isMock = false;
	}
}
