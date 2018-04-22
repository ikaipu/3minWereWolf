using System;
using Script;

[Serializable]
public class PlayerModel
{
    public string id;
    public EnumRole role;

    public PlayerModel(PlayerId id, EnumRole role)
    {
        this.id = PlayerIdExtensions.ToString(id);
        this.role = role;
    }
}