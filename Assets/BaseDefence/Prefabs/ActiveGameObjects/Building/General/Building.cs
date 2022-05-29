using UnityEngine;

public abstract class Building : MonoBehaviour
{
    [HideInInspector] public BuildingData buildingNextLevelData;
    [HideInInspector] public int placeInScene;

    protected BuildingData _firstLevel;
    protected int _currentLevel = 1;
    protected int _maxLevel;
    protected int _currentHP;
    protected static string[] _dataPathsWithLevels;
    public bool HaveImproveToNextLevel()
    {
        return _currentLevel < _maxLevel;
    }

    public void Upgrade()
    {
        _currentLevel++;
        ChangeLevel(_currentLevel);
        buildingNextLevelData = GetNextLevelData();
    }

    protected abstract void ChangeLevel(int level);

    public int GetPriceToNextLevel()
    {
        int index = GetIndex(_currentLevel + 1);
        string wallPath = _dataPathsWithLevels[index];

        return Resources.Load<BuildingData>(wallPath).price;
    }

    public abstract BuildingData GetNextLevelData();

    protected void InitializeBuilding<Data>(BuildingData buildingData, int level) where Data : BuildingData
    {
        if(_firstLevel == null) _firstLevel = Resources.Load<Data>(_dataPathsWithLevels[0]);
        _currentLevel = level;
        buildingNextLevelData = GetNextLevelData();
        _currentHP = buildingData.maxHP;
        _maxLevel = _dataPathsWithLevels.Length;
    }

    protected void Destroy()
    {
        ShopUI.instance.InstallParametrsAfterDestroy(_firstLevel, placeInScene);
        BuildingStateManager.instance.DestroyBuilding(placeInScene);
    }

    protected int GetIndex(int currentLevelIndex) => currentLevelIndex - 1;
}
