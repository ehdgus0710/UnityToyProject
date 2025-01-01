public enum EnemyType
{
    None = 0,
    Enemy,

    End
}

public static class EnemyTypeInfo
{
    public static readonly int Player = 1 << GetLayer.Player;
    public static readonly int Ground = 1 << GetLayer.Ground;
    public static readonly int Terrain = 1 << GetLayer.Terrain;


    public static System.Type GetEnemyStateType(EnemyType enemyType, EnemyStateType enemyStateType)
    {
        string componetName = enemyType.ToString() + enemyStateType.ToString() + "State";

        var type = System.Type.GetType(componetName);
        return type;
    }
}
public static class PlayerTypeInfo
{
    public static readonly int Player = 1 << GetLayer.Player;
    public static readonly int Ground = 1 << GetLayer.Ground;
    public static readonly int Terrain = 1 << GetLayer.Terrain;


    public static System.Type GetPlayerStateType(PlayerStateType playerStateType)
    {
        string componetName = "Player" + playerStateType.ToString() + "State";

        var type = System.Type.GetType(componetName);
        return type;
    }
}
