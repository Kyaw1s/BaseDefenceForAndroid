using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "GameInfo/LevelInfo")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private float _timeToWinInSeconds;
    [SerializeField] private float _timeBetweenEnemySpawn;
    [SerializeField] private int _moneyOnStart;

    public float timeToWinInSeconds => _timeToWinInSeconds;
    public float timeBetweenEnemySpawn => _timeBetweenEnemySpawn;
    public int moneyOnStart => _moneyOnStart;
}

public static class LevelInfoPaths
{
    private static string[] _LEVELS = new string[]
    {
        "Level1", "Level2", "Level3"
    };

    public static string GetPath(int level)
    {
        if (level > _LEVELS.Length) throw new System.Exception("Этого уровня нет");
        return _LEVELS[level - 1];
    }
}
