using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public static ShopUI instance;
    [SerializeField] private SoldObjectUI[] _soldObjectsUI;
    void Start()
    {
        instance = this;
        Bank.instance.CoinsCountChangedEvent += CheckAllButtonsActivities;

        TowerData towerData = Resources.Load<TowerData>(TowersDataPath.LEVEL_1);
        WallData wallData = Resources.Load<WallData>(WallsDataPaths.LEVEL_1);

        InitializeSoldObjects(towerData, Shop.instance.towerPrefab, 0, _soldObjectsUI.Length - 1);
        InitializeSoldObjects(wallData, Shop.instance.wallPrefab, _soldObjectsUI.Length - 1, _soldObjectsUI.Length);
    }

    public void InstallParametrsAfterDestroy(BuildingData buildingData, int placeNumber)
    {
        SoldObjectUI soldObjectUI = _soldObjectsUI[placeNumber];
        soldObjectUI.ChangeUIParametrs(buildingData);
        soldObjectUI.CheckButtonActivity();
    }
    private void InitializeSoldObjects(BuildingData buildingData, GameObject prefab, int start, int end)
    {
        for (int i = start; i < end; i++)
            _soldObjectsUI[i].Initialize(buildingData, prefab, i);
    }

    private void CheckAllButtonsActivities(object sender, int _, int __)
    {
        for (int i = 0; i < _soldObjectsUI.Length; i++)
            _soldObjectsUI[i].CheckButtonActivity();
    }
}
