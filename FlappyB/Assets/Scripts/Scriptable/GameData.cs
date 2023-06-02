using UnityEngine;

[DefaultExecutionOrder(-105)]

[CreateAssetMenu(menuName = "Scriptables/GameData")]
public class GameData : DataHolder
{
    #region Singleton
    private static GameData _default;
    public static GameData Default => _default;
    #endregion

    [Header("Obstacle")]
    [Space(10)]
    public float obstacleSpeed;
    public float spawnTime;
    public float offset;

    [Header("Tags")]
    [Space(10)]
    public string obstacleTag;
    public string scoreTag;

    [Header("Settings")]
    [Space(10)]
    public float speedMult;
    public float spawnTimeMult;

    override public void Init()
    {
        _default = this;
    }
}