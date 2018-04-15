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
	private Action<PlayerId> onVote;

	public void Set(PlayerModel playerModel,Action<PlayerId> onVote)
	{
		this.playerModel = playerModel;
		IdText.text = PlayerIdExtensions.ToName(playerModel.PlayerId);
		RoleText.text = playerModel.role.ToString();
		VoteTo.text = "";
		this.onVote = onVote;
	}

	public void SetVoteTo()
	{
		onVote(playerModel.PlayerId);
	}

	public void SetVotedNum(int votedNum)
	{
		VotedNum.text = votedNum.ToString();
	}
}
