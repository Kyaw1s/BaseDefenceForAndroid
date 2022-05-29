using UnityEngine;

[CreateAssetMenu(fileName = "Tower", menuName = "Gameplay/Building/Tower")]
public class TowerData : BuildingData
{
    [SerializeField] private int _damage;
    [SerializeField] private float _fireBallSpeed;
    [SerializeField] private float _timeBetweenAttack;

    public int damage => _damage;
    public float fireBallSpeed => _fireBallSpeed;
    public float timeBetweenAttack => _timeBetweenAttack;
}

public static class TowersDataPath
{
    public static readonly string LEVEL_1 = "Level1";
    public static readonly string LEVEL_2 = "Level2";
    public static readonly string LEVEL_3 = "Level3";
}

