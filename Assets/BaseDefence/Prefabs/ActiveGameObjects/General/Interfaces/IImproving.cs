public interface IImproving
{
    public bool HaveImproveToNextLevel();
    public int GetPriceToNextLevel();
    public void Upgrade();
    public BuildingData GetNextLevelData();
}
