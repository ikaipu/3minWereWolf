using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public int playerId;
    public string role;

    public PlayerModel(int playerId, string role)
    {
        this.playerId = playerId;
        this.role = role;
    }
}
