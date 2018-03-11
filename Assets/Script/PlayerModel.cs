using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class PlayerModel
{
    public int playerId;
    public EnumRole role;

    public PlayerModel(int playerId, EnumRole role)
    {
        this.playerId = playerId;
        this.role = role;
    }
}
