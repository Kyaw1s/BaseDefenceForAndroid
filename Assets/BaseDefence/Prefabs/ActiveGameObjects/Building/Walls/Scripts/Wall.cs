using UnityEngine;


public class Wall : Building, IGetDamageable, IImproving
{
    public event IGetDamageable.HealthOnWallChanged HealthChangedEvent;

    [SerializeField] Transform _spritesInHierarchy;

    private WallData _wallData;

    private void OnEnable()
    {
        _dataPathsWithLevels = new string[]
        {
            WallsDataPaths.LEVEL_1,
            WallsDataPaths.LEVEL_2,
            WallsDataPaths.LEVEL_3
        };

        ChangeLevel(_currentLevel);
        buildingNextLevelData = GetNextLevelData();
    }

    public void TakeDamage(int damage)
    {
        _currentHP -= damage;

        if (_currentHP <= 0) Destroy();

        HealthChangedEvent?.Invoke(_currentHP, _wallData.maxHP);
    }

    public override BuildingData GetNextLevelData()
    {
        if (HaveImproveToNextLevel()) return Resources.Load<WallData>(_dataPathsWithLevels[GetIndex(_currentLevel + 1)]);
        return null;
    }


    protected override void ChangeLevel(int level)
    {
        int index = GetIndex(level);
        string wallPath = _dataPathsWithLevels[index];
        _wallData = Resources.Load<WallData>(wallPath);

        foreach (SpriteRenderer e in _spritesInHierarchy.GetComponentsInChildren<SpriteRenderer>())
            e.sprite = _wallData.sprite;

        InitializeBuilding<WallData>(_wallData, level);

        HealthChangedEvent?.Invoke(_currentHP, _wallData.maxHP);
    }
}
