using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class PlayerModel
{
    public PlayerId PlayerId;
    public EnumRole role;

    public PlayerModel(PlayerId playerId, EnumRole role)
    {
        this.PlayerId = playerId;
        this.role = role;
    }
}
