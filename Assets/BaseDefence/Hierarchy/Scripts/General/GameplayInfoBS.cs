public static class GameplayInfoBS
{
    public static float timeToWinInSeconds { get; private set; }
    public static float timeBetweenEnemySpawn { get; private set; }
    public static int moneyOnStart { get; private set; }

    public static int level { get; private set; }

    public static void InstallValues(float timeToWinInSeconds, float timeBetweenEnemySpawn, int moneyOnStart, int level)
    {
        GameplayInfoBS.timeToWinInSeconds = timeToWinInSeconds;
        GameplayInfoBS.timeBetweenEnemySpawn = timeBetweenEnemySpawn;
        GameplayInfoBS.moneyOnStart = moneyOnStart;
        GameplayInfoBS.level = level;
    }
}
