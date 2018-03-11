using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

	public Text IdText;
	public Text RoleText;
	public Text[] voter;

	public void Set(PlayerModel playerModel)
	{
		IdText.text = "Player" + playerModel.playerId;
		RoleText.text = playerModel.role;
	}

	public void SetVoter(string playerId)
	{
		throw new System.NotImplementedException();
	}
}
