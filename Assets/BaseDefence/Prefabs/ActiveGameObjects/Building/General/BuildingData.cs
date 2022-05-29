using UnityEngine;

public abstract class BuildingData : ScriptableObject
{
    [SerializeField] private int _price;
    [SerializeField] private int _maxHP;
    [SerializeField] private Sprite _sprite;

    public int maxHP => _maxHP;
    public int price => _price;
    public Sprite sprite => _sprite;
}
