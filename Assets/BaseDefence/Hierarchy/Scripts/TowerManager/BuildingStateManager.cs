using UnityEngine;
using System;

public class BuildingStateManager : MonoBehaviour
{
    public static BuildingStateManager instance;

    [SerializeField] private Transform[] places;
    private GameObject[] buildings;
    private int _placesCount;

    private void Start()
    {
        _placesCount = places.Length;
        buildings = new GameObject[_placesCount];
        instance = this;
    }


    public BuildingData InvestInBuilding(GameObject prefab, int placeNumber)
    {
        if (buildings[placeNumber] == null) InstantiateBuilding(prefab, placeNumber);
        else ImproveBuilding(placeNumber);
        return buildings[placeNumber].GetComponent<Building>().buildingNextLevelData;
    }
    public void DestroyBuilding(int placeNumber)
    {
        CheckExeptions(placeNumber, false);
        Destroy(buildings[placeNumber]);
    }


    private void InstantiateBuilding(GameObject prefab, int placeNumber)
    {
        CheckExeptions(placeNumber, true);
        GameObject building = Instantiate(prefab, places[placeNumber].position, prefab.transform.rotation, places[placeNumber]);
        buildings[placeNumber] = building;
        building.GetComponent<Building>().placeInScene = placeNumber;
    }
    private void ImproveBuilding(int placeNumber)
    {
        CheckExeptions(placeNumber, false);
        buildings[placeNumber].GetComponent<IImproving>().Upgrade();
    }

    private void CheckExeptions(int placeNumber, bool isInstantiate)
    {
        if (placeNumber >= _placesCount) throw new Exception("Некорректный номер места. " + placeNumber + "из" + _placesCount);

        if(isInstantiate)
        {
            if(buildings[placeNumber] != null) throw new Exception("Тут уже стоит здание");
        }
        else
        {
            if (buildings[placeNumber] == null) throw new Exception("Тут нет здания");
        }
    }
}
