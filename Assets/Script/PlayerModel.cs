using System.Collections;
using System.Collections.Generic;
using Script;
using UnityEngine;

public class PlayerModel
{
    public EnumPlayer player;
    public EnumRole role;

    public PlayerModel(EnumPlayer player, EnumRole role)
    {
        this.player = player;
        this.role = role;
    }
}
