using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{

	public Text IdText;
	public Text RoleText;
	public Text VoteTo;
	public Text VotedNum;
	private PlayerModel playerModel;
	private Action<string> onVote;

	public void Set(PlayerModel playerModel,Action<string> onVote)
	{
		this.playerModel = playerModel;
		IdText.text = playerModel.id;
		RoleText.text = playerModel.role.ToString();
		VoteTo.text = "";
		this.onVote = onVote;
	}

	public void SetVoteTo()
	{
		onVote(playerModel.id);
	}

	public void SetVotedNum(int votedNum)
	{
		VotedNum.text = votedNum.ToString();
	}
}
