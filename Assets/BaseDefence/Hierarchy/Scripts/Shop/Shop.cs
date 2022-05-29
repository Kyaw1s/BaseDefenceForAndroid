using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;
    [SerializeField] private BuildingStateManager _buildingSpawner;
    [SerializeField] private GameObject _towerPrefab;
    [SerializeField] private GameObject _wallPrefab;

    public GameObject towerPrefab => _towerPrefab;
    public GameObject wallPrefab => _wallPrefab;

    private void Awake()
    {
        instance = this;
    }

    public BuildingData BuySoldObject(GameObject prefab, int price, int placeNumber)
    {
        Bank.instance.SpendCoins(this, price);
        return _buildingSpawner.InvestInBuilding(prefab, placeNumber);
    }
}


