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
		Debug.Log("test" + gameObject.name);

		Debug.Log("test" + playerModel.role.ToString());
		IdText.text = playerModel.player.ToString();
		RoleText.text = playerModel.role.ToString();
		VoteTo.text = "";
	}

	public void SetVoteTo(EnumPlayer player)
	{
		VoteTo.text = player.ToString();
	}

	public void SetVotedNum(int votedNum)
	{
		VotedNum.text = votedNum.ToString();
	}
}
