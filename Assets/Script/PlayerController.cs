using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public Text IdText;
	public Text RoleText;
	public Text VoteTo;
	public Text VotedNum;

	public void Set(PlayerModel playerModel)
	{
		IdText.text = PlayerIdExtensions.ToName(playerModel.PlayerId);
		RoleText.text = playerModel.role.ToString();
		VoteTo.text = "";
	}

	public void SetVoteTo(PlayerId playerId)
	{
		VoteTo.text = playerId.ToString();
	}

	public void SetVotedNum(int votedNum)
	{
		VotedNum.text = votedNum.ToString();
	}
}
