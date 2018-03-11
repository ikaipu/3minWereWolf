using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public Text IdText;
	public Text RoleText;
	public Text VoterList;

	public void Set(PlayerModel playerModel)
	{
		IdText.text = "Player" + playerModel.playerId;
		RoleText.text = playerModel.role;
		VoterList.text = "";
	}

	public void AddVoter(string playerId)
	{
		VoterList.text += playerId + "\n";
	}

	public void RemoveVoter(string playerId)
	{
		string before = VoterList.text;
		VoterList.text = before.Replace(playerId + "\n", "");
	}
}
